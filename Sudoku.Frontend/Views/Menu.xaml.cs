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
using System.Windows.Shapes;

namespace Sudoku.Frontend.Views
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void SolveSudokuButtonClick(object sender, RoutedEventArgs e)
        {
            ShowNotImplementedInfoBox();
        }

        private void SolveByAIClick(object sender, RoutedEventArgs e)
        {
            ShowNotImplementedInfoBox();
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ShowNotImplementedInfoBox()
        {
            MessageBox.Show($"This function is not implemented yet. Stay tuned.");
        }
    }
}
