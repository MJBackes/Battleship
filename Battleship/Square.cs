using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    abstract class Square
    {
        //MembVars
        public int RowNum;
        public int ColNum;
        public bool HasBeenGuessed;
        public bool GuessWasHit;
        public bool HasShip;
        public bool ChosenForPlacement;
        public bool isMyBoard;
        public Tile MyTile;
        //Constr

        //MembMeth
        public virtual void PrintOut()
        {
            Console.Write("|_" + getPrintOutput() + "_|");
        }
        public virtual void BeFilled(Tile tile)
        {
            HasShip = true;
            MyTile = tile;
        }
        public virtual bool BeGuessed()
        {
            HasBeenGuessed = true;
            if (MyTile.GetType().ToString() == "Battleship.ShipSection")
            {
                if (!MyTile.isHit)
                {
                    MyTile.isHit = true;
                    GuessWasHit = true;
                    return true;
                }
            }
            else
            {
                MyTile.wasGuessed = true;
            }
            return false;
        }
        public virtual string getPrintOutput()
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
                    if (MyTile.GetType().ToString() == "Battleship.ShipSection")
                    {
                        if (MyTile.isHit == true)
                        {
                            return " X ";
                        }
                    }
                    return " M ";
                }
                else
                {
                    if (MyTile != null)
                    {
                        if (MyTile.wasGuessed)
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
