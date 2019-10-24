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
        
        
        
        //Constr
        public BoardSquare(int row, int col,bool isMine)
        {
            RowNum = row;
            ColNum = col;
            HasBeenGuessed = false;
            GuessWasHit = false;
            isMyBoard = isMine;
        }
        //MembMeth
        public override void BeFilled(ShipSection section)
        {
            HasShip = true;
            ShipSec = section;
        }
        public override bool BeGuessed()
        {
            HasBeenGuessed = true;
            if(ShipSec != null)
            {
                if (!ShipSec.isHit)
                {
                    ShipSec.isHit = true;
                    GuessWasHit = true;
                    return true;
                }
            }
            else
            {
                OceanSec.wasGuessed = true;
            }
            return false;
        }
        public override string getPrintOutput()
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
                    if (ShipSec != null)
                    {
                        if (ShipSec.isHit == true)
                        {
                            return " X ";
                        }
                    }
                    return " M ";
                }
                else
                {
                    if (OceanSec != null)
                    {
                        if (OceanSec.wasGuessed)
                        {
                            return " O ";
                        }
                    }
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
