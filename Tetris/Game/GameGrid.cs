using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Game
{
    public class GameGrid
    {
        private readonly int[,]? Grid;

        public int Rows { get; }

        public int Columns { get; }

        public int this[int r, int c]
        {
            get => Grid[r, c];
            set => Grid[r, c] = value;
        }

        public GameGrid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Grid = new int[rows, columns];
        }

        public bool IsInside(int r, int c)
        {
            return r >= 0 && c >= 0 && r < Rows && c < Columns;
        }

        public bool IsEmpty(int r, int c)
        {
            return IsInside(r, c) && Grid[r, c] == 0;
        }

        public bool IsRowFull(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (Grid[r, c] == 0) 
                    return false;
            }

            return true;
        }

        public bool IsRowEmpty(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (Grid[r, c] != 0) return false;
            }

            return true;
        }

        private void ClearRow(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                Grid[r, c] = 0;
            }
        }

        private void MoveRowDown(int r, int numRows)
        {
            for (int c = 0; c < Columns; c++)
            {
                Grid[r + numRows, c] = Grid[r, c];
                Grid[r, c] = 0;
            }
        }

        public int ClearFullRows()
        {
            int cleared = 0;

            for (int r = Rows - 1; r >= 0; r--)
            {
                if (IsRowFull(r))
                {
                    ClearRow(r);
                    cleared++;
                }
                else if (cleared > 0)
                {
                    MoveRowDown(r, cleared);
                }
            }

            return cleared;
        }
    }
}
