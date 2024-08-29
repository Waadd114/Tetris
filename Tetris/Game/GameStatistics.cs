using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Utils;

namespace Tetris.Game
{
    public class GameStatistics
    {
        public Dictionary<BlockEnum,int> BlockStat{ get; private set; }

        public GameStatistics() 
        {
            BlockStat = new Dictionary<BlockEnum, int>
            {
                { BlockEnum.IBlock, 0 },
                { BlockEnum.JBlock, 0 },
                { BlockEnum.LBlock, 0 },
                { BlockEnum.OBlock, 0 },
                { BlockEnum.SBlock, 0 },
                { BlockEnum.TBlock, 0 },
                { BlockEnum.ZBlock, 0 },
            };
        }

        public void addBlock(BlockEnum blockId)
        {
            BlockStat[blockId] += 1;
        }
    }
}
