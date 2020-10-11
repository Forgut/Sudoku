﻿using Sudoku.Entities;
using Sudoku.Frontend.ViewModels;
using Sudoku.Logic.Solver;
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
    /// Interaction logic for AISolverPage.xaml
    /// </summary>
    public partial class AISolverPage : Page
    {
        private BoardViewModel _boardViewModel;
        private readonly Solver _solver;
        private readonly Board _board;
        public AISolverPage()
        {
            InitializeComponent();
        }

        public AISolverPage(Board board) : this()
        {
            _board = board;
            _solver = new Solver(_board);
            _boardViewModel = new BoardViewModel(_board);
            this.DataContext = _boardViewModel;
            SetBorders();
            SetValues();
        }

        private void SetValues()
        {
            for (int i = 0; i < Board.SIZE; i++)
            {
                for (int j = 0; j < Board.SIZE; j++)
                {
                    TextBlock textBlock = new TextBlock();
                    Binding binding = new Binding("Value");
                    binding.Source = _boardViewModel[i, j];
                    textBlock.Name = $"Text{i}{j}";
                    textBlock.SetBinding(TextBlock.TextProperty, binding);
                    textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                    textBlock.VerticalAlignment = VerticalAlignment.Center;
                    this.SudokuGrid.Children.Add(textBlock);
                    Grid.SetRow(textBlock, i);
                    Grid.SetColumn(textBlock, j);
                }
            //< TextBlock Text = "{Binding Tiles[0].Value}" Grid.Column = "0" Grid.Row = "0" HorizontalAlignment = "Center" VerticalAlignment = "Center" />

            }
        }

        private void SetBorders()
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
                    this.SudokuGrid.Children.Add(border);
                    Grid.SetRow(border, i);
                    Grid.SetColumn(border, j);
                }
            }
        }

        private void NextStepClick(object sender, RoutedEventArgs e)
        {
            _solver.FindNextNumber();
            _boardViewModel = new BoardViewModel(_board);
            this.DataContext = _boardViewModel;
            if (_board.IsFull())
            {

            }
        }
    }
}