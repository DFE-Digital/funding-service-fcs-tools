using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BuildQuery
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Configuration;
    using System.Net;
    using System.Windows.Threading;
    using System.Runtime.InteropServices;
    using TfsData.Models;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {

        public MainWindowModel _mainModel;
           
        public MainWindow()
        {
            InitializeComponent();
            _mainModel = new MainWindowModel(new NetworkCredential(
                    ConfigurationManager.AppSettings["tfsUsername"],
                    ConfigurationManager.AppSettings["tfsPassword"],
                    ConfigurationManager.AppSettings["tfsDomain"]))
            {
                BrokenBuilds = new ObservableCollection<string>(),
                BuildList = new ObservableCollection<FctBuildDetail>(),
                BuildText = "",
                KeyBuildList = new ObservableCollection<FctBuildDetail>(),
                LastRefresh = DateTime.MinValue,
                TeamBurnDowns = new ObservableCollection<FctBurndown>()
            };

            this.DataContext = _mainModel;
        
            //run on ui thread initially so that screen is initialized
            _mainModel.GetTfsData();

        }

        public MainWindowModel MainModel
        {
            get { return _mainModel; }
            set 
            { 
                _mainModel = value;
                OnPropertyChanged("MainModel");
            }
        }

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        
        private static void PressScrollLock()
        {
            const byte vkScroll = 0x91;
            const byte keyeventfKeyup = 0x2;

            keybd_event(vkScroll, 0x45, 0, (UIntPtr)0);
            keybd_event(vkScroll, 0x45, keyeventfKeyup, (UIntPtr)0);
        }

        private static void Timer1Tick(object sender, EventArgs e)
        {
            //disable screen saver
            PressScrollLock();
            PressScrollLock();
        }
        
        DispatcherTimer _screenSaverSupressTimer = new DispatcherTimer();
        DispatcherTimer _tfsLoadTimer = new DispatcherTimer();
        DispatcherTimer _mainWindowChangeTimer = new DispatcherTimer();
        DispatcherTimer _buildTextTimer = new DispatcherTimer();
              
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            _screenSaverSupressTimer.Interval = TimeSpan.FromSeconds(118);
            _screenSaverSupressTimer.Tick += screenSaverSuppressTimer_Tick;
            _screenSaverSupressTimer.Start();
            
            _tfsLoadTimer.Interval = TimeSpan.FromSeconds(60);
            _tfsLoadTimer.Tick += tfsLoadTimer_Tick;
            _tfsLoadTimer.Start();

            _mainWindowChangeTimer.Interval = TimeSpan.FromSeconds(10);
            _mainWindowChangeTimer.Tick += mainWindowChangeTimer_Tick;
            _mainWindowChangeTimer.Start();

            _buildTextTimer.Interval = TimeSpan.FromSeconds(3);
            _buildTextTimer.Tick += buildTextTimer_Tick;
            _buildTextTimer.Start();
        }

        void buildTextTimer_Tick(object sender, EventArgs e)
        {
            _mainModel.SetBuildText();
        }

        void screenSaverSuppressTimer_Tick(object sender, EventArgs e)
        {
            PressScrollLock();
            PressScrollLock();
        }

        void mainWindowChangeTimer_Tick(object sender, EventArgs e)
        {
            
            var keyBuilds = ((UserControl) this.FindName("KeyBuilds"));
            var allBuilds =((UserControl)this.FindName("AllBuilds"));
            var burndowns = ((UserControl)this.FindName("Burndowns"));
            if (allBuilds.Visibility == System.Windows.Visibility.Visible)
            {
                allBuilds.Visibility = System.Windows.Visibility.Hidden;
                keyBuilds.Visibility = System.Windows.Visibility.Visible;
                burndowns.Visibility = System.Windows.Visibility.Hidden;
            }
            else if (keyBuilds.Visibility == System.Windows.Visibility.Visible)
            {
                allBuilds.Visibility = System.Windows.Visibility.Hidden;
                keyBuilds.Visibility = System.Windows.Visibility.Hidden;
                burndowns.Visibility = System.Windows.Visibility.Visible;
            }
            else if (burndowns.Visibility == System.Windows.Visibility.Visible)
            {
                allBuilds.Visibility = System.Windows.Visibility.Visible;
                keyBuilds.Visibility = System.Windows.Visibility.Hidden;
                burndowns.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        void tfsLoadTimer_Tick(object sender, EventArgs e)
        {
            Task.Run(() => { _mainModel.GetTfsData(); });
        }

        
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propName));
            }
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            var pauseButton = (Button) sender;
            if ((string) (pauseButton.Content) == "Pause")
            {
                pauseButton.Content = "Play";
                _mainWindowChangeTimer.Stop();
            }
            else
            {
                pauseButton.Content = "Pause";
                _mainWindowChangeTimer.Start();
            }
           
        }
    }
}
