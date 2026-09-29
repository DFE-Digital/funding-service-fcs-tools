namespace WpfControls.Audit
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Input;

    public class AuditTableViewModel : INotifyPropertyChanged
    {
        private readonly string _environment;
        private DateTime _startDate = DateTime.Now.Date;
        private DateTime _endDate = DateTime.Now.Date.AddDays(1);
        private string messageType;

        public AuditTableViewModel(string environment)
        {
            _environment = environment;
        }

        public IReadOnlyCollection<AuditMessage> AuditMessages => AuditRepository.GetAuditMessages(_environment, StartDate, EndDate, MessageType, BusinessKey);

        public ICommand CopyMessageBodyCommand => new DelegateCommand(o => true, CopyMessageToTheClipboard);

        public DelegateCommand SearchCommand => new DelegateCommand(o => AllowSearch, SearchMessages);
        
        public ICommand CopyPropertiesBodyCommand => new DelegateCommand(o => true, CopyPropertiesToTheClipboard);

        public string MessageType
        {
            get => messageType;
            set
            {
                messageType = value;
                OnPropertyChanged(nameof(AllowSearch));
            } 
        }

        public string BusinessKey { get; set; }

        public DateTime StartDate
        {
            get => _startDate;
            set 
            { 
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        public AuditMessage SelectedRow { get; set; }

        public bool AllowSearch => !string.IsNullOrEmpty(MessageType);

        public event PropertyChangedEventHandler PropertyChanged;

        private void CopyMessageToTheClipboard(object o)
        {
            Clipboard.SetText(SelectedRow.MessageAsJson);
        }

        private void CopyPropertiesToTheClipboard(object o)
        {
            Clipboard.SetText(SelectedRow.MessagePropertiesAsJson);
        }

        private void SearchMessages(object o)
        {
            OnPropertyChanged(nameof(AuditMessages));
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            handler?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public class DelegateCommand : ICommand
        {
            private readonly Predicate<object> _canExecute;
            private readonly Action<object> _execute;

            public DelegateCommand(Predicate<object> canexecute, Action<object> execute)
            {
                _canExecute = canexecute;
                _execute = execute;
            }
           
            public bool CanExecute(object parameter)
            {
                return _canExecute == null || _canExecute(parameter);
            }


            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }

            public void Execute(object parameter)
            {
                _execute(parameter);
            }
        }
    }
}
