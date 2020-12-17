using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goals.Models
{
    public class GoalsModel : INotifyPropertyChanged
    {
        private string _goalName;
        private string _goalComment;
        private bool _isDone;
        public string goalName
        {
            get { return _goalName; }
            set
            {
                if (_goalName == value) return;
                _goalName = value;
                OnPropertyChanged("goalName");

            }
        }
        public string goalComment
        {
            get { return _goalComment; }
            set
            {
                if (_goalComment == value) return;
                _goalComment = value;
                OnPropertyChanged("goalComment");
            }
        }
        public bool isDone
        {
            get { return _isDone; }
            set
            {
                if (_isDone == value) return;
                _isDone = value;
                OnPropertyChanged("isDone");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
