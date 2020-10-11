using Sudoku.Entities;
using Sudoku.Frontend.Views.AISolvePages;
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
    /// <summary>
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }


        private void SolveSudokuButtonClick(object sender, RoutedEventArgs e)
        {
            ShowNotImplementedInfoBox();
        }

        private void SolveByAIClick(object sender, RoutedEventArgs e)
        {
            var insertSudokuPage = new InsertSudokuPage();
            int?[,] boardArray = new int?[,]
            {
                { 5, null, null, null, 2, null, null, null, null },
                { 8, 3, null, null, 4, 9, null, null, 7 },
                { 6, null, null, 5, null, 1, 9, 8, null },

                { null, 5, null, 4, null, 6, 8, 3, 2 },
                { null, null, 4, null, 5, 3, null, null, null },
                { null, null, 6, null, null, null, 7, null, 5 },

                { null, null, 5, null, 6, null, 3, null, null },
                { null, null, null, 1, null, null, null, 2, 9 },
                { null, null, null, null, 7, 4, null, 6, null },
            };
            var board = new Board(boardArray);
            var aiSolverPage = new AISolverPage(board);
            NavigationService.Navigate(aiSolverPage);
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
