using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFDemo.ViewModel
{
    // Define an internal class named CalcolatriceViewModel, which implements the INotifyPropertyChanged interface
    internal class CalcolatriceViewModel : INotifyPropertyChanged
    {
        // Declare a private field to store the risultato (result) as a string, initialized with "0"
        private string _risultato = "0";

        // Create a public property named risultato, which allows access to _risultato
        public string risultato
        {
            get
            {
                return _risultato;
            }
            set
            {
                // When the value of risultato is set, update the private field and raise the PropertyChanged event
                _risultato = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("risultato"));
            }
        }

        // Declare an event named PropertyChanged, which is part of the INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;

        // Define a method named Tasto that accepts a string value as an argument
        public void Tasto(string value)
        {
            // Check if the current risultato is "0"
            if (risultato == "0")
            {
                // If risultato is "0," replace it with an empty string and then append the provided value
                risultato = "";
                risultato += value;
            }
            else
            {
                // If risultato is not "0," simply append the provided value
                risultato += value;
            }
        }
    }
}
