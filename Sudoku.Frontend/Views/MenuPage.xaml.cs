﻿using Sudoku.Entities;
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
            NavigationService.Navigate(insertSudokuPage);
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
