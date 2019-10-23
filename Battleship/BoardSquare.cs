using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class BoardSquare
    {
        //MembVars
        public int RowNum;
        public int ColNum;
        public bool HasShip;
        public ShipSection ShipSec;
        private bool IsBoardHeading;
        //Constr
        public BoardSquare(int row, int col, bool heading = false)
        {
            RowNum = row;
            ColNum = col;
            IsBoardHeading = heading;
        }
        //MembMeth
        public void BeFilled(Ship ship,ShipSection section)
        {
            HasShip = true;
            ShipSec = section;
        }
        public void PrintOut()
        {

        }
    }
}
