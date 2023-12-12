using System;
using System.Windows;
using System.Windows.Controls;
using WPFDemo.ViewModel;

namespace WPFDemo.View
{
    /// <summary>
    /// Logica di interazione per StudenteView.xaml
    /// </summary>
    public partial class StudenteRandomView : Page
    {
        private StudenteRandomViewModel viewModel;
        public StudenteRandomView()
        {
            InitializeComponent();

            viewModel = new StudenteRandomViewModel();
            DataContext = viewModel;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await viewModel.RandomStudent();
        }
    }
}
