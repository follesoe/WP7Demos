using System.ComponentModel;

namespace AppModelDemo
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsDirty { get; set; }
       
        private string _expences;
        private string _justification;
        private string _destination;
        public string _start;
        public string _end;

        public string Expences
        {
            get { return _expences; }
            set
            {
                _expences = value;
                RaisePropertyChanged("Expences");
            }
        }

        public string Destination
        {
            get { return _destination; }
            set 
            { 
                _destination = value;
                RaisePropertyChanged("Destination");
            }
        }

        public string Justification
        {
            get { return _justification; }
            set
            {
                _justification = value;
                RaisePropertyChanged("Justification");
            }
        }

        public string Start
        {
            get { return _start; }
            set
            {
                _start = value;
                RaisePropertyChanged("Start");
            }
        }

        public string End
        {
            get { return _end; }
            set
            {
                _end = value;
                RaisePropertyChanged("End");
            }
        }


        public void RaisePropertyChanged(string property)
        {
            IsDirty = true;
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
