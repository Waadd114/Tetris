using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Tetris.Utils;

namespace Tetris.Blocks
{
    public abstract class Block
    {
        protected abstract Position[][] Tiles { get; }

        protected abstract Position StartOffset { get; }

        public abstract int Id { get; }

        private int RotationState;

        private Position Offset;

        public Block()
        {
            Offset = new Position(StartOffset.Row, StartOffset.Column);
        }

        public IEnumerable<Position> TilePositions()
        {
            foreach (Position p in Tiles[RotationState])
            {
                yield return new Position(p.Row + Offset.Row, p.Column + Offset.Column);
            }
        }

        public void RotateCW()
        {
            RotationState = (RotationState + 1) % Tiles.Length;
        }

        public void RotateCCW()
        {
            if (RotationState == 0)
                RotationState = Tiles.Length - 1;
            else
                RotationState--;
        }

        public void Move(int rows, int columns)
        {
            Offset.Row += rows;
            Offset.Column += columns;
        }

        public void Reset()
        {
            RotationState = 0;
            Offset.Row = StartOffset.Row;
            Offset.Column = StartOffset.Column;
        }
    }
}
