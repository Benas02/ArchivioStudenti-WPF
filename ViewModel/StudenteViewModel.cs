using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WPFDemo.ControllerEF;
using WPFDemo.ModelEF;

namespace WPFDemo.ViewModel
{
    internal class StudenteViewModel : BaseViewModel
    {
        private bool isNew;

        #region "Studente"
        private Studenti _studente;

		public Studenti Studente
		{
			get { return _studente; }
			set { _studente = value; propertyChanged("Studente"); }
		}
        #endregion

        #region "Titolo"
        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        #endregion

        #region "Button Go"
        private string _buttonGo;

        public string ButtonGo
        {
            get { return _buttonGo; }
            set { _buttonGo = value; }
        }

        #endregion

        #region "Corsi"
        private List<Corsi> _corsi;

        public List<Corsi> Corsi
        {
            get { return _corsi; }
            set { _corsi = value; }
        }
        #endregion

// ------------------------------------------------------------------------------------------------------------------------

        #region "Costruttore"
        public StudenteViewModel()
        {
            isNew = true;
            _studente = new Studenti(DateTime.Today);
            this.StudenteViewModelAsync();
            _title = "Nuovo Studente";
            _buttonGo = "Aggiungi";
        }

        public StudenteViewModel(Studenti studente)
        {
            isNew= false;
            _studente = studente;

            //this.StudenteViewModelAsync();
            CorsiController.GetAllCorsi().ContinueWith( t => Corsi = t.Result );
            
            _title = "Modifica Studente";
            _buttonGo = "Modifica";
        }
        #endregion

// ------------------------------------------------------------------------------------------------------------------------

        #region "Studente View Model Async"
        public async void StudenteViewModelAsync()
        {
            Corsi = await CorsiController.GetAllCorsi();
        }
        #endregion

// ------------------------------------------------------------------------------------------------------------------------

        #region "Conferma Nuovo Studente"
        public async void Conferma()
        {
            if(isNew)
            {
                await StudentiController.AddStudenteAsync(Studente);
                //Studente = new Studente(DateTime.Today);

                Studente.Cognome = "";
                Studente.Nome = "";
                Studente.DataNascita = DateTime.Today;
            }
            else
            {
                await StudentiController.EditStudenteAsync(Studente);
            }                
        }
        #endregion

        #region "Annulla Nuovo Studente"
        public void Annulla()
        {

        }
        #endregion
    }
}
