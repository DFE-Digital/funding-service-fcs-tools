using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.TeamFoundation.Build.WebApi;
using Microsoft.TeamFoundation.Core.WebApi;
using Microsoft.TeamFoundation.SourceControl.WebApi;
using Microsoft.VisualStudio.Services.WebApi;
using ReleaseBranchUtilityLib;

namespace ReleaseBranchUtility
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        ReleaseBranchAdder _rba;
        VssConnection _connection;
        TeamProject _teamProject;

        private void MainForm_Load(object sender, EventArgs e)
        {
            _rba = new ReleaseBranchAdder();
            tbOrganisationUri.Text = "https://dev.azure.com/sfa-fcs";
            tbTeamProject.Text = "FCT";
            tbRepository.Text = "FCS";
        }

        private int? _currentReleaseNumber = null;
        private char? _nextReleaseLetter = null;
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                (_connection, _teamProject) = ReleaseBranchAdder.GetConnectionAndProject(tbOrganisationUri.Text, tbTeamProject.Text);
                btnConnect.BackColor = Color.LightGreen;
                btnConnect.Enabled = false;

                // find the most recent R[0-9]+[a-z]? tag and use that to calculate the next major and minor release names

                GitHttpClient gitClient = _connection.GetClient<GitHttpClient>();

                var refs = gitClient.GetRefsAsync(project: tbTeamProject.Text, repositoryId: tbRepository.Text, "tags").Result;

                string releaseNumberGroup = "releaseNumber";
                string releaseLetterGroup = "releaseLetter";
                Regex tagRegex = new Regex($"^refs/tags/[Rr](?<{releaseNumberGroup}>[0-9]+)(?<{releaseLetterGroup}>[a-z]?)$");

                var mostRecentTag = refs
                    .Select(r => tagRegex.Match(r.Name))
                    .Where(m => m.Success)
                    .Select(m => new
                        {Match = m, Number = m.Value.Split('/').Last().Split('R').Last().GetNumberPartAndSuffix()})
                    .OrderByDescending(m => m.Number.numberPart)
                    .ThenByDescending(m => m.Number.suffix)
                    .FirstOrDefault()?.Match;

                var others = refs
                    .Select(r => tagRegex.Match(r.Name))
                    .Where(m => m.Success)
                    .OrderByDescending(m => m.Value)
                    .ToList();

                if (mostRecentTag != null && mostRecentTag.Groups[releaseNumberGroup].Success && int.TryParse(mostRecentTag.Groups[releaseNumberGroup].Value, out int releaseNumber))
                {
                    Log($"Latest tag found was {mostRecentTag.Value}");
                    _currentReleaseNumber = releaseNumber;

                    if (mostRecentTag.Groups[releaseLetterGroup].Success)
                    {
                        _nextReleaseLetter = mostRecentTag.Groups[releaseLetterGroup].Value.Length > 0 ? (char?)mostRecentTag.Groups[releaseLetterGroup].Value[0] : null;
                        if (_nextReleaseLetter < 'z')
                            _nextReleaseLetter++;
                        else
                            _nextReleaseLetter = null;
                    }
                    else
                    {
                        _nextReleaseLetter = 'a';
                    }

                    btnNextMajor.Text = $"Create R{_currentReleaseNumber+1} Branch";
                    btnNextMajor.Enabled = true;

                    btnNextMinor.Text = $"Create R{_currentReleaseNumber}{_nextReleaseLetter} Branch";
                    btnNextMinor.Enabled = true;
                }

                tbCommitId_TextChanged(null, null);


                // now find the latest build for the DEV CD TO DAT definition and grab the commit id from that
                // as that may be the one we need for the next major release option

                BuildHttpClient buildClient = _connection.GetClient<BuildHttpClient>();
                var builds = buildClient.GetBuildsAsync(_teamProject.Id, new int[] { 450 }).Result;
                var latestBuild = builds.OrderByDescending(b => b.FinishTime).FirstOrDefault();
                tbCommitId.Text = latestBuild.SourceVersion;
                btnValidate_Click(null, null);

                Log($"Commit Id {tbCommitId.Text} discovered from build {latestBuild.BuildNumber}");
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            if (tbCommitId.TextLength != 40 || _connection == null)
            {
                btnValidate.Enabled = false;
            }
            else
            {
                try
                {
                    var gitClient = ReleaseBranchAdder.GitClient(_connection);

                    var commit = gitClient.GetCommitAsync(tbTeamProject.Text, tbCommitId.Text, tbRepository.Text).Result;

                    tbCommitId.BackColor = Color.LightGreen;

                    if (_currentReleaseNumber.HasValue)
                    {
                        btnNextMajor.Enabled = true;
                    }
                }
                catch(Exception ex)
                {
                    tbCommitId.BackColor = Color.Salmon;
                    Log(ex.InnerException.Message);                
                }
            }
        }

        private void tbCommitId_TextChanged(object sender, EventArgs e)
        {
            btnValidate.Enabled = (tbCommitId.Text.Length == 40 && _connection != null);
            btnNextMajor.Enabled = false;
            tbCommitId.BackColor = Color.White;
        }

        private void btnCreateBranch_Click(object sender, EventArgs e)
        {
            ReleaseBranchAdder.Execute(
                tbOrganisationUri.Text,
                tbTeamProject.Text,
                tbRepository.Text,
                tbCommitId.Text,
                int.Parse(tbReleaseNumber.Text),
                (tbReleaseLetter.Text.Length == 0) ? null : (char?)tbReleaseLetter.Text.First(),
                cbForce.Checked,
                Log);

            Log("We are finished");
        }

        private void Log(string logLine)
        {
            tbLog.AppendText($"{DateTime.Now.TimeOfDay} : {logLine}{Environment.NewLine}");
        }

        bool tbCommitId_nonLetteEntered;

        private void tbCommitId_KeyDown(object sender, KeyEventArgs e)
        {
            tbCommitId_nonLetteEntered = !
                (e.KeyCode == Keys.Back ||
                 ((e.KeyCode == Keys.V || e.KeyCode == Keys.C) && Control.ModifierKeys == Keys.Control) || 
                 (((e.KeyCode >= Keys.A && e.KeyCode <= Keys.F) || 
                   (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) || 
                   (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)) 
                  && Control.ModifierKeys == Keys.None)
                );
        }

        private void tbCommitId__KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = tbCommitId_nonLetteEntered;
        }



        private bool tbReleaseNumber_nonNumberEntered = false;

        private void tbReleaseNumber_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            tbReleaseNumber_nonNumberEntered = !
                ((((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) || (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)) && Control.ModifierKeys != Keys.Shift) ||
                    e.KeyCode == Keys.Back);
        }

        private void tbReleaseNumber_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = tbReleaseNumber_nonNumberEntered;
        }

        bool tbReleaseLetter_nonLetteEntered;

        private void tbReleaseLetter_KeyDown(object sender, KeyEventArgs e)
        {
            tbReleaseLetter_nonLetteEntered = ! ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z && Control.ModifierKeys == Keys.None) || e.KeyCode == Keys.Back);
        }

        private void tbReleaseLetter__KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = tbReleaseLetter_nonLetteEntered;
        }

        private void btnNextMajor_Click(object sender, EventArgs e)
        {
            tbReleaseNumber.Text = (_currentReleaseNumber.Value + 1).ToString();
            tbReleaseLetter.Text = string.Empty;
            btnCreateBranch_Click(null, null);
        }

        private void btnNextMinor_Click(object sender, EventArgs e)
        {
            tbReleaseNumber.Text = _currentReleaseNumber.Value.ToString();
            tbReleaseLetter.Text = _nextReleaseLetter.Value.ToString();
            btnCreateBranch_Click(null, null);
        }
    }
}
