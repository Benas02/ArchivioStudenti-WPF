using System;
using System.Threading.Tasks;
using WPFDemo.ControllerEF;
using WPFDemo.ModelEF;

namespace WPFDemo.ViewModel
{
    internal class StudenteRandomViewModel : BaseViewModel
    {
        #region "Studente"
        private Studenti _studente;

		public Studenti studente
        {
			get { return _studente; }
			set { _studente = value; propertyChanged("studente"); }
		}
        #endregion

        #region "Studente Random"
        public async Task RandomStudent()
        {
            studente = await StudentiController.GetRandomStudent();
        }
        #endregion
    }
}
