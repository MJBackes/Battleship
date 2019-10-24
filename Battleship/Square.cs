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
        //Constr

        //MembMeth
        public virtual void PrintOut()
        {
            bool isMyBoard = true;
            Console.Write("|_" + getPrintOutput(isMyBoard) + "_|");
        }
        public abstract string getPrintOutput(bool isMyBoard);
        public abstract void BeFilled(ShipSection section);
    }
}
