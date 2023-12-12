using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDemo.ViewModel
{
    internal class MainWindowViewModel : BaseViewModel
	{ 
        #region "IsLogged"
        private bool _isLogged = false;

		public bool IsLogged
		{
			get { return _isLogged; }
			set { _isLogged = value; propertyChanged("IsLogged"); }
		}
        #endregion

        #region "Logout"
        public void Logout()
        {
            IsLogged = false;
        }
        #endregion
    }
}
