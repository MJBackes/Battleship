using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    abstract class Ship
    {
        //MembVars
        public int Length;
        public BoardSquare StartingSquare;
        public string Orientation;
        public bool isSunk;
        public int HitsTaken;
        //Constr

        //MembMeth
        public bool CheckIfSunk()
        {
            if(HitsTaken >= Length)
            {
                return true;
            }
            return false;
        }
        public void BeHit()
        {
            HitsTaken++;
            CheckIfSunk();
        }
    }
}
