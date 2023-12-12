using System;
using System.Windows;
using WPFDemo.View;
using WPFDemo.ViewModel;

namespace WPFDemo
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel viewModel;

        #region "Costruttore"
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainWindowViewModel();
            
            DataContext = viewModel;
        }
        #endregion

        #region "... Click"
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Logout();
            NavigationService.NavigationService.Navigate(new LoginView());
        }

        private void Calcolatrice_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.NavigationService.Navigate(new CalcolatriceView());
        }

        private void StudenteRandom_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.NavigationService.Navigate(new StudenteRandomView());
        }

        private void GestioneStudenti_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.NavigationService.Navigate(new StudentiView());
        }
        #endregion
    }
}
