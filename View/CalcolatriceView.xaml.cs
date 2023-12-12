using System;
using System.Windows;
using System.Windows.Controls;
using WPFDemo.ViewModel;

namespace WPFDemo.View
{
    /// <summary>
    /// Logica di interazione per CalcolatriceView.xaml
    /// </summary>
    public partial class CalcolatriceView : Page
    {
        // Declare a private field to hold an instance of the CalcolatriceViewModel
        private CalcolatriceViewModel viewModel;

        // Constructor for the Calcolatrice class
        public CalcolatriceView()
        {
            // Initialize the user interface components
            InitializeComponent();

            // Create an instance of CalcolatriceViewModel
            viewModel = new CalcolatriceViewModel();

            // Set the DataContext of this window to the viewModel
            // This establishes a data binding between the UI and the view model
            DataContext = viewModel;
        }

        // Event handler for a button click
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Get the button that triggered the click event
            Button button = (Button)sender;

            // Extract the content (text) of the button and convert it to a string
            string value = button.Content.ToString();

            // When the button is clicked, call the Tasto method of the viewModel,
            // passing the extracted value as an argument. This value likely represents
            // the number or operator associated with the clicked button on the calculator.
            viewModel.Tasto(value);
        }
    }
}
