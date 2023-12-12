using System;
using System.Windows;
using WPFDemo.ModelEF;
using WPFDemo.ViewModel;

namespace WPFDemo.View
{
    /// <summary>
    /// Logica di interazione per StudenteView.xaml
    /// </summary>
    public partial class StudenteView : Window
    {
        private StudenteViewModel viewModel;

        #region "Costruttore"
        public StudenteView()
        {
            InitializeComponent();
            viewModel = new StudenteViewModel();

            DataContext = viewModel;
        }

        public StudenteView(Studenti studente)
        {
            InitializeComponent();
            viewModel = new StudenteViewModel(studente);

            DataContext = viewModel;
        }
        #endregion

        // ------------------------------------------------------------------------------------------------------------------------

        #region "... Click"
        private void Annulla_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Annulla();
            Close();
        }       

        private void Conferma_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Conferma();
            Close();
        }
        #endregion
    }
}
