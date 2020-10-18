using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sudoku.Frontend.Views.UserSolvePages
{
    /// <summary>
    /// Interaction logic for UserChooseSudokuPage.xaml
    /// </summary>
    public partial class UserChooseSudokuPage : Page
    {
        public UserChooseSudokuPage()
        {
            InitializeComponent();
        }

        private void HardButtonClick(object sender, RoutedEventArgs e)
        {
            ShowNotImplementedInfoBox();
        }

        private void MediumButtonClick(object sender, RoutedEventArgs e)
        {
            ShowNotImplementedInfoBox();
        }

        private void EasyButtonClick(object sender, RoutedEventArgs e)
        {
            ShowNotImplementedInfoBox();
        }

        private void ShowNotImplementedInfoBox()
        {
            MessageBox.Show($"This function is not implemented yet. Stay tuned.");
        }
    }
}
