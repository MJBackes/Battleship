using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Carrier : Ship
    {
        //MembVars


        //Constr
        public Carrier(BoardSquare start, string facing)
        {
            Length = 5;
            HitsTaken = 0;
            isSunk = false;
            StartingSquare = start;
            Orientation = facing;
        }
        //MembMeth
    }
}
