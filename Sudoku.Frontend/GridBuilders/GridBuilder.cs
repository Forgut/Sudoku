using Sudoku.Entities;
using Sudoku.Frontend.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Sudoku.Frontend.GridBuilders
{
    public class GridBuilder
    {
        private Grid _grid;
        public GridBuilder(Grid grid)
        {
            _grid = grid;
        }

        public void DrawBorders()
        {
            for (int i = 0; i < Board.SIZE; i++)
            {
                for (int j = 0; j < Board.SIZE; j++)
                {
                    Border border = new Border()
                    {
                        BorderBrush = Brushes.Black,
                        BorderThickness = new Thickness(1)
                    };
                    _grid.Children.Add(border);
                    Grid.SetRow(border, i);
                    Grid.SetColumn(border, j);
                }
            }
        }

        public void DrawValues(BoardViewModel model)
        {
            for (int i = 0; i < Board.SIZE; i++)
            {
                for (int j = 0; j < Board.SIZE; j++)
                {
                    if (model[i, j].HasValue)
                    {
                        TextBlock textBlock = new TextBlock();

                        Binding binding = new Binding(nameof(TileViewModel.Value));
                        binding.Source = model[i, j];

                        textBlock.SetBinding(TextBlock.TextProperty, binding);
                        textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                        textBlock.VerticalAlignment = VerticalAlignment.Center;

                        _grid.Children.Add(textBlock);
                        Grid.SetRow(textBlock, i);
                        Grid.SetColumn(textBlock, j);
                    }
                    else
                    {
                        Grid innerGrid = new Grid();
                        innerGrid.ColumnDefinitions.Add(new ColumnDefinition());
                        innerGrid.ColumnDefinitions.Add(new ColumnDefinition());
                        innerGrid.ColumnDefinitions.Add(new ColumnDefinition());
                        innerGrid.RowDefinitions.Add(new RowDefinition());
                        innerGrid.RowDefinitions.Add(new RowDefinition());
                        innerGrid.RowDefinitions.Add(new RowDefinition());
                        foreach (var possibility in model[i,j].Possibilities)
                        {
                            TextBlock textBlock = new TextBlock();
                            textBlock.Text = possibility.ToString();
                            textBlock.FontSize = 10;
                            textBlock.Foreground = Brushes.Blue;

                            textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                            textBlock.VerticalAlignment = VerticalAlignment.Center;

                            innerGrid.Children.Add(textBlock);
                            Grid.SetRow(textBlock, (possibility - 1) / 3);
                            Grid.SetColumn(textBlock, (possibility - 1)  % 3);
                        }
                        _grid.Children.Add(innerGrid);
                        Grid.SetRow(innerGrid, i);
                        Grid.SetColumn(innerGrid, j);
                    }
                }
            }
        }

        public void DrawValues()
        {
            for (int i = 0; i < Board.SIZE; i++)
            {
                for (int j = 0; j < Board.SIZE; j++)
                {
                    TextBlock textBlock = new TextBlock();
                    textBlock.HorizontalAlignment = HorizontalAlignment.Stretch;
                    textBlock.VerticalAlignment = VerticalAlignment.Stretch;

                    _grid.Children.Add(textBlock);
                    Grid.SetRow(textBlock, i);
                    Grid.SetColumn(textBlock, j);
                }
            }
        }
    }
}
