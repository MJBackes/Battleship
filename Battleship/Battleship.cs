using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Battleship : Ship
    {
        //MembVars


        //Constr
        public Battleship(BoardSquare start, string facing)
        {
            Length = 4;
            HitsTaken = 0;
            isSunk = false;
            StartingSquare = start;
            Orientation = facing;
        }
        //MembMeth
    }
}
