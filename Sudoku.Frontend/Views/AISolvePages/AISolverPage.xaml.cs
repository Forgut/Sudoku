using Sudoku.Entities;
using Sudoku.Frontend.GridBuilders;
using Sudoku.Frontend.ViewModels;
using Sudoku.Logic.Solver;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Sudoku.Frontend.Views.AISolvePages
{
    public partial class AISolverPage : Page
    {
        private BoardViewModel _boardViewModel;
        private readonly Solver _solver;
        private readonly Board _board;
        private readonly GridBuilder _gridBuilder;
        public AISolverPage()
        {
            InitializeComponent();
        }

        public AISolverPage(Board board) : this()
        {
            _board = board;
            _solver = new Solver(_board);
            _boardViewModel = new BoardViewModel(_board);
            _gridBuilder = new GridBuilder(this.SudokuGrid);
            _gridBuilder.DrawBorders();
            _gridBuilder.DrawValues(_boardViewModel);
        }

        private void ClearChildren()
        {
            SudokuGrid.Children.Clear();
        }

        private void NextStepClick(object sender, RoutedEventArgs e)
        {
            _solver.FindNextNumber();
            //todo - find a way to do it properly by INotifyPropertyChanged
            ClearChildren();
            _gridBuilder.DrawBorders();
            _gridBuilder.DrawValues(_boardViewModel);
            if (_board.IsCorrect())
            {
                MessageBox.Show("Sudoku solved!");
                this.NextStepButton.IsEnabled = false;
            }

        }

        private void BackToMenuButtonClick(object sender, RoutedEventArgs e)
        {
            var menuPage = new MenuPage();
            NavigationService.Navigate(menuPage);
        }
    }
}
