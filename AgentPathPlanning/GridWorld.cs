﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AgentPathPlanning
{
    class GridWorld
    {
        private Cell[,] cells;

        // Number of rows and columns (default is 10x10)
        private int ROWS = 10;
        private int COLUMNS = 10;

        // Cell size
        private const int CELL_HEIGHT = 60;
        private const int CELL_WIDTH = 60;

        // Cell colors (RGB byte arrays)
        private SolidColorBrush UNOCCUPIED_CELL_BACKGROUND_COLOR = new SolidColorBrush(Color.FromRgb(244, 244, 244));
        private SolidColorBrush OCCUPIED_CELL_BACKGROUND_COLOR = new SolidColorBrush(Color.FromRgb(218, 164, 160));
        private SolidColorBrush OBSTACLE_CELL_BACKGROUND_COLOR = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        private SolidColorBrush CELL_STROKE_COLOR = new SolidColorBrush(Color.FromRgb(0, 0, 0));

        private int currentRowIndex = 0;
        private int currentColumnIndex = 0;

        public GridWorld(Grid grid, Cell[,] cells)
        {
            ROWS = cells.GetLength(0);
            COLUMNS = cells.GetLength(1);

            // Build the cells
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLUMNS; j++)
                {
                    Rectangle rectangle = new Rectangle();

                    rectangle.Name = "cell" + i + j;

                    rectangle.Height = CELL_HEIGHT;
                    rectangle.Width = CELL_WIDTH;

                    rectangle.VerticalAlignment = VerticalAlignment.Top;
                    rectangle.HorizontalAlignment = HorizontalAlignment.Left;

                    rectangle.Margin = new Thickness(j * CELL_WIDTH, i * CELL_HEIGHT, 0, 0);

                    rectangle.Stroke = CELL_STROKE_COLOR;

                    if (cells[i, j].IsObstacle())
                    {
                        rectangle.Fill = OBSTACLE_CELL_BACKGROUND_COLOR;
                    }
                    else
                    {
                        rectangle.Fill = UNOCCUPIED_CELL_BACKGROUND_COLOR;
                    }

                    cells[i, j].SetRectangle(rectangle);

                    grid.Children.Add(cells[i, j].GetRectangle());
                }
            }
        }

        private int GetRowIndexFromId(String id)
        {
            return id.Replace("cell", "")[0];
        }

        private int GetColumnIndexFromId(String id)
        {
            return id.Replace("cell", "")[1];
        }

        public int GetCurrentRowIndex()
        {
            return currentRowIndex;
        }

        public int GetCurrentColumnIndex()
        {
            return currentColumnIndex;
        }

        public bool CanMove(Direction direction)
        {
            return true;
        }
    }
}
