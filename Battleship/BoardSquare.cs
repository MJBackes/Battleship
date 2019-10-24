using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class BoardSquare : Square
    {
        //MembVars
        
        
        public ShipSection ShipSec;
        //Constr
        public BoardSquare(int row, int col)
        {
            RowNum = row;
            ColNum = col;
            HasBeenGuessed = false;
            GuessWasHit = false;
        }
        //MembMeth
        public void BeFilled(Ship ship,ShipSection section)
        {
            HasShip = true;
            ShipSec = section;
        }
        public override string getPrintOutput()
        {
            if (HasBeenGuessed)
            {
                if (GuessWasHit)
                {
                    return " X ";
                }
                return " O ";
            }
            if (ChosenForPlacement)
            {
                ChosenForPlacement = false;
                return " X ";
            }
            return "   ";
        }
    }
}
