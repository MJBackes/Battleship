using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Destroyer : Ship
    {
        //MembVars


        //Constr
        public Destroyer(BoardSquare start, string facing)
        {
            Length = 2;
            HitsTaken = 0;
            isSunk = false;
            StartingSquare = start;
            Orientation = facing;
        }
        //MembMeth
    }
}
