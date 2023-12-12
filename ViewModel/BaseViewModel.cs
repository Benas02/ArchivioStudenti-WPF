using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace WPFDemo.ViewModel
{
    internal class BaseViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public bool HasErrors => _errors.Count > 0;

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _errors.FirstOrDefault(x => x.Key == propertyName).Value;
        }

        #region "Property Changed"
        public void propertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region "Error Changed"
        public void errorChanged(string filed)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(filed));
        }
        #endregion

        protected Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        #region "Add Errors"
        public void addErrors(string filed, string msg)
        {
            if(!_errors.ContainsKey(filed))
            {
                _errors.Add(filed, new List<string>());
            }

            _errors[filed].Add(msg);
            errorChanged(filed);
        }
        #endregion

        #region "Clear Errors"
        public void ClearErrors(string filed)
        {
            if (_errors.Remove(filed))
            {
                errorChanged(filed);
            }
        }
        #endregion
    }
}
