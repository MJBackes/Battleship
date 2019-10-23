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
        //Constr
        public BoardSquare(int row, int col)
        {
            RowNum = row;
            ColNum = col;
        }
        //MembMeth
        public void BeFilled(Ship ship,int partOfShip)
        {

        }
    }
}
