namespace AzureDiagnosticLogReader
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Drawing;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Table;
    using System.Threading.Tasks;
    using System.Text;
    using System.Threading;
    using MoreLinq;
    using Newtonsoft.Json;
    using System.Text.RegularExpressions;

    public partial class AzureLogForm : Form
    {
        const int InformationLevel = 4;
        private const string AllLogEntries = "All";
        private const string InfoAndMoreCritical = "Info";
        private const string HightlightErrorTextValues = "(Exception|fail|error)";

        public class GridViewEntry
        {
            public string EntryDateTime { get; set; }
            public int EventId { get; set; }
            public string Message { get; set; }
            public string RoleInstance { get; set; }
            public string DeploymentName { get; set; }
            public int Level { get; set; }
        }

        private readonly Dictionary<string, IReadOnlyCollection<DeploymentInfo>> _environmentList = new Dictionary<string, IReadOnlyCollection<DeploymentInfo>>();

        private GridViewEntry[] _retrievedEntries;

        private string _lastPartitionKeyFetched;
        private readonly System.Threading.Timer _autoRefreshTimer;
        private int _numLogRowsRead = 0;

        public AzureLogForm()
        {
            InitializeComponent();

            _autoRefreshTimer = new System.Threading.Timer(OnRefreshTimerTick);
            cbLogLevel.Items.Add(InfoAndMoreCritical);
            cbLogLevel.Items.Add(AllLogEntries);
            cbLogLevel.SelectedIndex = 0;
        }

        private async void RunButton_Click(object sender, EventArgs e)
        {
            RunButton.Enabled = false;
            LogDisplayView.DataSource = null;
            LogDisplayView.Refresh();

            _lastPartitionKeyFetched = null;
            _retrievedEntries = new GridViewEntry[0];
            await FillTable();

            FilterTextBox.Enabled = true;
            btnFilter.Enabled = true;
            btnClear.Enabled = true;
            btnUpdateLog.Enabled = true;
            cbAutoRefresh.Enabled = true;

            RunButton.Enabled = true;
        }

        private async Task FillTable()
        {
            IReadOnlyCollection<DeploymentInfo> selectedDeploymentInfos =
                _environmentList[EnvironmentComboBox.SelectedItem.ToString()];

            List<Task<IList<GridViewEntry>>> taskList = new List<Task<IList<GridViewEntry>>>();

            LogDisplayView.DataSource = null;
            LogDisplayView.Refresh();
            _numLogRowsRead = 0;
            Cursor = Cursors.WaitCursor;

            selectedDeploymentInfos.ForEach(deploymentInfo =>
            {
                taskList.Add(GetGridViewEntries(deploymentInfo.DeploymentId, deploymentInfo.StorageKey, deploymentInfo.DeploymentName));
            });

            IList<GridViewEntry>[] arrayOfEntryLists = await Task.WhenAll(taskList);

            _retrievedEntries = arrayOfEntryLists.SelectMany(a => a) .OrderBy(entry => entry.EntryDateTime).ToArray();

            LogDisplayView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            btnFilter_Click(null, null);

            Cursor = Cursors.Default;
        }

        private async Task<IList<GridViewEntry>> GetGridViewEntries(string deploymentId, string storageConnectionStringKey, string deploymentName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings[storageConnectionStringKey].ConnectionString);

            CloudTableClient cloudTableClient = storageAccount.CreateCloudTableClient();

            CloudTable table = cloudTableClient.GetTableReference("WADLogsTable");

            var fromPartitionKey = "0" + FromDateTimePicker.Value.Ticks;
            if (_lastPartitionKeyFetched != null)
            {
                fromPartitionKey = _lastPartitionKeyFetched;
            }

            var toPartitionKey = "0" + ToDateTimePicker1.Value.Ticks;

            var rangeQuery = new TableQuery<SimpleEntity>()
                .Where(
                    TableQuery.CombineFilters(
                        TableQuery.CombineFilters(
                            TableQuery.GenerateFilterCondition(
                                "PartitionKey",
                                _lastPartitionKeyFetched == null ? QueryComparisons.GreaterThanOrEqual : QueryComparisons.GreaterThan,
                                fromPartitionKey),
                            TableOperators.And,
                            TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.LessThanOrEqual, toPartitionKey)
                        ),
                        TableOperators.And,
                        TableQuery.GenerateFilterCondition("DeploymentId", QueryComparisons.Equal, deploymentId)
                    ));

            TableContinuationToken continuationToken = null;

            IList<GridViewEntry> entries = new List<GridViewEntry>();

            do
            {
                var segmentResults = await table.ExecuteQuerySegmentedAsync(rangeQuery, continuationToken);
                continuationToken = segmentResults.ContinuationToken;

                foreach (var entity in segmentResults)
                {
                    string message;

                    string rawMessage = entity.Message;
                    if (rawMessage.StartsWith("EventName=\"MessageEvent\""))
                    {
                        message = rawMessage.Substring(33);
                    }
                    else if (rawMessage.StartsWith("EventName=\"FormattedMessageEvent\""))
                    {
                        message = rawMessage.Substring(51);
                    }
                    else if (rawMessage.StartsWith("EventName=\"DirectWrite\""))
                    {
                        message = rawMessage.Substring(32);
                    }
                    else
                    {
                        message = rawMessage;
                    }

                    int traceSourceStart = message.LastIndexOf("TraceSource=\"");
                    if (traceSourceStart > -1)
                    {
                        message = message.Substring(0, traceSourceStart - 1);
                    }

                    string roleInstanceString = entity.RoleInstance;
                    int lastIndex = roleInstanceString.LastIndexOf("_");
                    if (lastIndex >= 0)
                    {
                        roleInstanceString = roleInstanceString.Substring(lastIndex + 1);
                    }

                    var roleInstance = roleInstanceString;

                    if (!cbInstanceFilter.Items.Contains(roleInstance))
                    {
                        cbInstanceFilter.Items.Add(roleInstance);
                    }

                    int eventId = entity.EventId;

                    if (!cbEventIdFilter.Items.Contains(eventId))
                    {
                        cbEventIdFilter.Items.Add(eventId);
                    }

                    int? level = entity.Level;
                    GridViewEntry entry = new GridViewEntry
                    {
                        EntryDateTime = message.Substring(1, 23),
                        EventId = eventId,
                        Message = message,
                        RoleInstance = roleInstance,
                        DeploymentName = deploymentName,
                        Level = level.Value
                    };

                    entries.Add(entry);

                    if (string.Compare(entity.PartitionKey, _lastPartitionKeyFetched) > 0)
                    {
                        _lastPartitionKeyFetched = entity.PartitionKey;
                    }
                }
                Interlocked.Add(ref _numLogRowsRead, segmentResults.Count());
                toolStripStatusLabel1.Text = string.Format("{0} entries retrieved", _numLogRowsRead);


            } while (continuationToken != null);

            return entries;
        }

        private void AzureLogForm_Load(object sender, EventArgs e)
        {
            //MMA moved environment values to app config
            SetEnvironmentList();

            EnvironmentComboBox.Items.AddRange(_environmentList.Select(x => (object)x.Key).ToArray());

            int indexOfDatServiceBus = EnvironmentComboBox.FindString("fcs-dat");
            if (indexOfDatServiceBus >= 0)
            {
                EnvironmentComboBox.SelectedIndex = indexOfDatServiceBus;
            }

            DateTime now = DateTime.Now;

            int hourAdjust = now.IsDaylightSavingTime() ? -60 : 0;
            FromDateTimePicker.Value = now.AddMinutes(-10 + hourAdjust).AddSeconds(0 - now.Second);
            ToDateTimePicker1.Value = now.AddMinutes(hourAdjust).AddSeconds(60 - now.Second);

            var version = Assembly.GetExecutingAssembly().GetName().Version;
            Text = "FCT Diagnostics Log Reader - Version " + version.Major + "." + version.Minor;
        }

        private void SetEnvironmentList()
        {
            ConfigurationManager.AppSettings.AllKeys
                .Where(p => p.Contains("fct-") || p.Contains("fcs-"))
                .OrderBy(p => p)
                .ToList()
                .ForEach(key =>
                {
                    _environmentList.Add(key, GetConfigVal(key));
                });
        }

        private IReadOnlyCollection<DeploymentInfo> GetConfigVal(string environment)
        {
            string deploymentInfosJson = ConfigurationManager.AppSettings[environment];

            return JsonConvert.DeserializeObject<List<DeploymentInfo>>(deploymentInfosJson);
        }

        private void LogDisplayView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var gridView = sender as DataGridView;
                int eventId = int.Parse((string)gridView.Rows[e.RowIndex].Cells[2].FormattedValue);
                string rowMessage = (string)gridView.Rows[e.RowIndex].Cells[3].FormattedValue;

                string filterText = "0=\"";

                if (eventId == 205 || eventId == 213)
                {
                    filterText = rowMessage.Substring(rowMessage.LastIndexOf(' ') + 1, 36);
                }
                else
                {
                    switch (eventId)
                    {
                        case 200:
                            filterText = "0=\"";
                            break;
                        case 100:
                        case 204:
                        case 205:
                        case 215:
                        case 370:
                        case 371:
                            filterText = "1=\"";
                            break;
                        case 900:
                            filterText = "3=\"";
                            break;
                        case 921:
                            filterText = "with Correlation Id ";
                            break;
                    }

                    filterText = rowMessage.Substring(rowMessage.LastIndexOf(filterText) + filterText.Length, 36);
                }
                FilterTextBox.Text = filterText;

                foreach (var item in cbEventIdFilter.CheckBoxItems)
                {
                    item.Checked = false;
                }

                btnFilter_Click(null, null);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            LogDisplayView.CurrentCell = null;

            var checkedEventIdItems = cbEventIdFilter.CheckBoxItems.Where(i => i.Checked).Select(i => (int)i.ComboBoxItem).ToArray();
            bool skipEventIdCheck = checkedEventIdItems.Count() == 0;

            var checkedInstanceItems = cbInstanceFilter.CheckBoxItems.Where(i => i.Checked).Select(i => (string)i.ComboBoxItem);
            bool skipInstaceCheck = checkedInstanceItems.Count() == 0;

            bool filterTextIsEmpty = string.IsNullOrEmpty(FilterTextBox.Text);

            var filteredEntries = _retrievedEntries
                .Where(entry =>
                           (skipEventIdCheck || checkedEventIdItems.Contains(entry.EventId))
                        && (skipInstaceCheck || checkedInstanceItems.Any(x => x == entry.RoleInstance))
                        && (filterTextIsEmpty || entry.Message.Contains(FilterTextBox.Text)))
                .ToArray();

            LogDisplayView.DataSource = filteredEntries.Where(LevelFilter).ToList();

            ScrollToEnd();

            toolStripStatusLabel1.Text = string.Format("{0} of {1} rows displayed", filteredEntries.Length, _retrievedEntries.Length);

            HighlightErrors();

            Cursor = Cursors.Default;
        }

        private void ScrollToEnd()
        {
            if (LogDisplayView.RowCount > 0)
            {
                LogDisplayView.FirstDisplayedScrollingRowIndex = LogDisplayView.RowCount - 1;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            LogDisplayView.DataSource = _retrievedEntries;
            FilterTextBox.Text = string.Empty;

            cbEventIdFilter.CheckBoxItems.ForEach(i => i.Checked = false);

            toolStripStatusLabel1.Text = string.Format("All {0} rows displayed", _retrievedEntries.Length);

            cbInstanceFilter.CheckBoxItems.ForEach(i => i.Checked = false);

            HighlightErrors();

            ScrollToEnd();
        }

        private async void btnUpdateLog_Click(object sender, EventArgs e)
        {
            //// this method updates the to date to now and refreshed the logs from the last entry already 
            //// fetched to the most recent, basically allowing you to manually tail a log file

            DateTime now = DateTime.Now;
            int hourAdjust = now.IsDaylightSavingTime() ? -60 : 0;
            ToDateTimePicker1.Value = now.AddMinutes(hourAdjust).AddSeconds(60 - now.Second);

            await FillTable();
        }

        private void LogDisplayView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var gridView = sender as DataGridView;
                tbSelectedLine.Text = gridView.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
            }
        }

        private void cbAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAutoRefresh.Checked)
            {
                _autoRefreshTimer.Change(TimeSpan.FromSeconds(60), TimeSpan.FromSeconds(60));
            }
            else
            {
                _autoRefreshTimer.Change(-1, -1);
            }
        }

        delegate void OnRefreshTimerTickDelegate(object state);

        private void OnRefreshTimerTick(object state)
        {
            if (ToDateTimePicker1.InvokeRequired)
            {
                var del = new OnRefreshTimerTickDelegate(OnRefreshTimerTick);
                Invoke(del, new object());
            }
            else
            {
                btnUpdateLog_Click(null, null);
            }
        }

        private void FilterTextBox_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnFilter;
        }

        private void FilterTextBox_Leave(object sender, EventArgs e)
        {
            AcceptButton = RunButton;
        }

        private void LogDisplayView_SelectionChanged(object sender, EventArgs e)
        {
            List<int> rowId = new List<int>();
            foreach (DataGridViewCell cell in LogDisplayView.SelectedCells)
            {
                if (!rowId.Contains(cell.RowIndex))
                {
                    rowId.Add(cell.RowIndex);
                }
            }

            toolStripStatusLabel2.Text = string.Format("{0} of {1} rows selected", rowId.Count, LogDisplayView.Rows.Count);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_retrievedEntries?.Any() ?? false)
            {
                SaveToCsv();
            }
        }

        private void SaveToCsv()
        {
            StringBuilder sb = new StringBuilder();
            const string doubleQuote = "\"";
            const char doubleQuoteChar = '\"';
            const char singleQuoteChar = '\'';

            sb.AppendLine("EntryDateTime,RoleInstance,EventId,Message,DeploymentName");
            _retrievedEntries.ForEach(
                e => sb.AppendLine($"{e.EntryDateTime},{e.RoleInstance},{e.EventId}," +
                                   $"{doubleQuote + e.Message.Replace(doubleQuoteChar, singleQuoteChar) + doubleQuote }," +
                                   $"{e.DeploymentName}"));

            using (SaveFileDialog fd = new SaveFileDialog())
            {
                fd.Filter = @"CSV file (*.csv)|*.csv|All Files (*.*)|*.*";
                fd.FileName = $"LogReaderOutput {DateTime.Now:yyyy-MM-dd HH-mm-ss}";

                if (fd.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.Stream stream = fd.OpenFile())
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(stream))
                    {
                        sw.Write(sb.ToString());
                        sw.Close();
                        stream.Close();
                    }
                }
            }
        }

        private void cbLogLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLogLevel.SelectedItem.Equals(AllLogEntries))
            {
                LevelFilter = l => true;

            }
            else if (cbLogLevel.SelectedItem.Equals(InfoAndMoreCritical))
            {
                LevelFilter = DefaultLevelFilter;
            }

            LogDisplayView.DataSource = _retrievedEntries?.Where(LevelFilter).ToList();
        }

        private static Func<GridViewEntry, bool> DefaultLevelFilter => l => l.Level <= InformationLevel;

        private Func<GridViewEntry, bool> LevelFilter { get; set; } = DefaultLevelFilter;

        private void HighlightErrors()
        {
            foreach (DataGridViewRow row in LogDisplayView.Rows)
            {
                try
                {
                    row.DefaultCellStyle.BackColor =
                        Regex.IsMatch(row.Cells[3].Value.ToString(), HightlightErrorTextValues) ? Color.LightCoral : Color.White;
                }
                catch (Exception)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }
    }
}
