using Sudoku.Entities;
using Sudoku.Frontend.Views.AISolvePages;
using Sudoku.Frontend.Views.UserSolvePages;
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

namespace Sudoku.Frontend.Views
{
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }


        private void SolveSudokuButtonClick(object sender, RoutedEventArgs e)
        {
            var userChooseSudokuPage = new UserChooseSudokuPage();
            NavigationService.Navigate(userChooseSudokuPage);
        }

        private void SolveByAIClick(object sender, RoutedEventArgs e)
        {
            var insertSudokuPage = new InsertSudokuPage();
            NavigationService.Navigate(insertSudokuPage);
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
