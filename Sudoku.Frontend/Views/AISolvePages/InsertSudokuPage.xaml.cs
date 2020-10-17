using Sudoku.Entities;
using Sudoku.Frontend.GridBuilders;
using Sudoku.Frontend.ViewModels;
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

namespace Sudoku.Frontend.Views.AISolvePages
{
    /// <summary>
    /// Interaction logic for InsertSudokuPage.xaml
    /// </summary>
    public partial class InsertSudokuPage : Page
    {
        Board _board;
        GridBuilder _gridBuilder;
        TextBlock _selectedTextBlock;
        public InsertSudokuPage()
        {
            InitializeComponent();
            _board = Board.GetEmptyBoard();
            this.SudokuGrid.Focus();
            _gridBuilder = new GridBuilder(this.SudokuGrid);
            _gridBuilder.DrawBorders();
            _gridBuilder.DrawValues();
        }

        private void SolveItClick(object sender, RoutedEventArgs e)
        {
            var aiSolverPage = new AISolverPage(_board);
            NavigationService.Navigate(aiSolverPage);
        }

        private void SudokuGridMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (_selectedTextBlock != null)
                    _selectedTextBlock.Background = Brushes.Transparent;

                _selectedTextBlock = e.OriginalSource as TextBlock;
                _selectedTextBlock.Background = Brushes.LightGray;
            }
            catch (Exception)
            {

            }
        }

        private void SudokuGridKeyDown(object sender, KeyEventArgs e)
        {
            if (_selectedTextBlock == null)
                return;
            var key = e.Key;
            if (!KeyIsNumericOrSpace(key))
                return;
            int? value = GetKeyValue(key);
            var x = Grid.GetRow(_selectedTextBlock);
            var y = Grid.GetColumn(_selectedTextBlock);
            if (value.HasValue)
            {
                _board[x, y].SetValue(value.Value);
                _selectedTextBlock.Text = value.ToString();
            }
            else
            {
                _selectedTextBlock.Text = string.Empty;
                _board[x, y].ClearValue();
            }
        }

        private bool KeyIsNumericOrSpace(Key key)
        {
            return
                key == Key.D1 ||
                key == Key.D2 ||
                key == Key.D3 ||
                key == Key.D4 ||
                key == Key.D5 ||
                key == Key.D6 ||
                key == Key.D7 ||
                key == Key.D8 ||
                key == Key.D9 ||
                key == Key.Space;
        }
        private int? GetKeyValue(Key key)
        {
            switch(key)
            {
                case Key.D1: return 1;
                case Key.D2: return 2;
                case Key.D3: return 3;
                case Key.D4: return 4;
                case Key.D5: return 5;
                case Key.D6: return 6;
                case Key.D7: return 7;
                case Key.D8: return 8;
                case Key.D9: return 9;
                case Key.Space: return null;
                default: return null;
            }
        }
    }
}
