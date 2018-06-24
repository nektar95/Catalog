using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        protected void AddError(string propertyName, string errorMessage)
        {
            List<string> propertyErrors = null;
            if (_errors.ContainsKey(propertyName))
            {
                propertyErrors = _errors[propertyName];
            }
            else
            {
                propertyErrors = new List<string>();
                _errors.Add(propertyName, propertyErrors);
            }
            propertyErrors.Add(errorMessage);
        }

        protected void RemoveErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                _errors.Remove(propertyName);
            }
        }

        #region INotifyDataErrorInfo
        public bool HasErrors => _errors.Count > 0;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                return _errors[propertyName];
            }
            return null;
        }
        #endregion
        protected void RaiseErrorChanged(string propertyName)
        {
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
