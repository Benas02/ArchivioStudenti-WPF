using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WPFDemo.ControllerEF;
using WPFDemo.ModelEF;
using WPFDemo.View;

namespace WPFDemo.ViewModel
{
    internal class StudentiViewModel : BaseViewModel
    {
        #region "Filtro"
        private string _filtro = "";

		public string Filtro
		{
			get { return _filtro; }
			set { _filtro = value; propertyChanged("Filtro"); Filtra(); }
		}
		#endregion

		#region "Lista Studenti"
		private ObservableCollection<Studenti> _studenti;

        public ObservableCollection<Studenti> Studenti
        {
            get { return _studenti; }
            set { _studenti = value; propertyChanged("Studenti"); }
        }
        #endregion

        #region "Studente Selezionato"
        private Studenti _StudenteSelezionato;

        public Studenti StudenteSelezionato
        {
            get { return _StudenteSelezionato; }
            set { _StudenteSelezionato = value; propertyChanged("StudenteSelezionato"); propertyChanged("canDelete"); }
        }
        #endregion

        #region "Is Studente Selezionato"
        public bool canDelete
        {
            get { return StudenteSelezionato != null; }
        }
        #endregion

// ------------------------------------------------------------------------------------------------------------------------

        #region "Costruttore"
        public StudentiViewModel()
        {
            StudentiController.GetStudente(Filtro).ContinueWith(t => Studenti = new ObservableCollection<Studenti>(t.Result));
            FiltraBackground();
        }
        #endregion

// ------------------------------------------------------------------------------------------------------------------------

        #region "Studenti View Model Async"
        public async void StudentiViewModelAsync()
        {
            _studenti = new ObservableCollection<Studenti>(await StudentiController.GetStudente(Filtro));
        }
        #endregion

// ------------------------------------------------------------------------------------------------------------------------

        #region "Filtra Background"
        public async void FiltraBackground()
        {
            while (true)
            {
                await Task.Delay(10000);
                await Filtra();
            }
        }
        #endregion

        #region "Filtra Studente"
        public async Task Filtra() 
		{
            Studenti = new ObservableCollection<Studenti>(await StudentiController.GetStudente(Filtro));
        }
        #endregion

        #region "Elimina Studente"
        public async Task Elimina()
        {
            if (StudenteSelezionato != null)
            {
                await StudentiController.Delete(StudenteSelezionato.IdStudente);

                Filtro = "";
                StudenteSelezionato = null;

                await Filtra();
            }
        }
        #endregion

        #region "Nuovo Studente"
        public async Task Nuovo()
        {
            StudenteView view = new StudenteView();
            view.ShowDialog();
            await Filtra();
        }
        #endregion

        #region "Modifica Studente"
        public async Task Edit()
        {
            if (StudenteSelezionato != null)
            {
                StudenteView view = new StudenteView(StudenteSelezionato);
                view.ShowDialog();
                await Filtra();
            }               
        }
        #endregion
    }
}
