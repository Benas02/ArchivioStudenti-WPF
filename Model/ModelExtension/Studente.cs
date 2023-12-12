using System;
using System.ComponentModel;

namespace WPFDemo.Model
{
    public partial class Studente : INotifyPropertyChanged
    {
        #region "DataBase Not Mapped"
        public string CognomeNome { get { return $"{Cognome} {Nome}"; } }
        public string CognomeNomeCorso { get { return $"{Cognome} {Nome} - {Corso.Nome}"; } }
        #endregion

        #region "Costruttore"
        public Studente()
        {

        }

        public Studente(DateTime dataNascita)
        {
            DataNascita = dataNascita;
        }

        public Studente(string cognome, string nome, DateTime dataNascita, int idCorso)
        {
            Cognome = cognome;
            Nome = nome;
            DataNascita = dataNascita;
            this.idCorso = idCorso;
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
