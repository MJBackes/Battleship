﻿using System;
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
            Console.Write("|_" + getPrintOutput() + "_|");
        }
        public abstract string getPrintOutput();
    }
}