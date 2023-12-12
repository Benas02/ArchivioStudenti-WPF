using System;
using System.ComponentModel;

namespace WPFDemo.Model
{
    public partial class Studente 
    {
        #region "DataBase Mapped"
        public int IdStudente { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascita { get; set; }
        public int idCorso { get; set; }

        public Corso Corso { get; set; }
        #endregion     
    }
}
