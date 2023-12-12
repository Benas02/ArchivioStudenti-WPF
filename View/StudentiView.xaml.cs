using System;
using System.Windows;
using System.Windows.Controls;
using WPFDemo.ViewModel;

namespace WPFDemo.View
{
    /// <summary>
    /// Logica di interazione per StudentiView.xaml
    /// </summary>
    public partial class StudentiView : Page
    {
        private StudentiViewModel viewModel;

        #region "Costruttore"
        public StudentiView()
        {
            InitializeComponent();
            viewModel = new StudentiViewModel();

            DataContext = viewModel;
        }
        #endregion

        #region "... Click"
        private async void Filtra_Click(object sender, RoutedEventArgs e)
        {
            await viewModel.Filtra();
        }

        private async void Elimina_Click(object sender, RoutedEventArgs e)
        {
            await viewModel.Elimina();
        }
        
        private async void Nuovo_Click(object sender, RoutedEventArgs e)
        {
            await viewModel.Nuovo();
        }

        private async void DataGrid_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            await viewModel.Edit();
        }
        #endregion

    }
}
