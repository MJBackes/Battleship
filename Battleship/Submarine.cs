using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Submarine : Ship
    {
        //MembVars


        //Constr
        public Submarine(BoardSquare start, string facing)
        {
            Length = 3;
            HitsTaken = 0;
            isSunk = false;
            StartingSquare = start;
            Orientation = facing;
        }
        //MembMeth
    }
}
