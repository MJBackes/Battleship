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
        public override void BeFilled(ShipSection section)
        {
            HasShip = true;
            ShipSec = section;
        }
        public void BeGuessed()
        {
            if(ShipSec != null)
            {
                ShipSec.isHit = true;
            }
        }
        public override string getPrintOutput(bool isMyBoard)
        {
            if (!isMyBoard)
            {
                if (HasBeenGuessed)
                {
                    if (GuessWasHit)
                    {
                        return " X ";
                    }
                    return " O ";
                }
            }
            else
            {
                if (HasShip)
                {
                    if (ShipSec != null){
                        if(ShipSec.isHit == true) { 
                        return " X ";
                            }
                    }
                    return " M ";
                }
                if (ChosenForPlacement)
                {
                    ChosenForPlacement = false;
                    return " X ";
                }
            }
            return "   ";
        }
    }
}
