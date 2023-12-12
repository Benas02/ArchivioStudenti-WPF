using System.Windows;
using System.Windows.Controls;
using WPFDemo.ViewModel;

namespace WPFDemo.View
{
    /// <summary>
    /// Logica di interazione per LoginView.xaml
    /// </summary>
    public partial class LoginView : Page
    {
        // Declare a private field to hold the LoginViewModel instance
        private LoginViewModel viewModel;

        #region "Constructor"
        // Constructor for the LoginView class
        public LoginView()
        {
            // Initialize the LoginView component
            InitializeComponent();

            // Create a new instance of LoginViewModel
            viewModel = new LoginViewModel();

            // Set the DataContext of this view to the LoginViewModel instance
            DataContext = viewModel;
        }
        #endregion

        #region "... Click"
        // Event handler for a button click (assuming it's linked to a button in the XAML)
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Call the login() method on the LoginViewModel
            if (viewModel.Login())
            {
                NavigationService.Navigate(new StudentiView());
            }         
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            viewModel.password = ((PasswordBox)sender).Password;
        }
        #endregion
    }
}
