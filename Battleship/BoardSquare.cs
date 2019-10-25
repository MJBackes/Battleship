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
        
    }
}
