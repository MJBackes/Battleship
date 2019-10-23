using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Board
    {
        //MembVars
        BoardSquare[][] Matrix;

        //Constr
        public Board()
        {
            Matrix = new BoardSquare[21][];
            for(int i = 0; i < Matrix.Length; i++)
            {
                Matrix[i] = new BoardSquare[21];
            }
        }
        //MembMeth
        private void FillBoard()
        {
            for(int i = 0; i < Matrix.Length; i++)
            {
                for(int j = 0; j < Matrix[i].Length; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        Matrix[i][j] = new BoardSquare(i, j, true);
                    }
                    else
                    {
                        Matrix[i][j] = new BoardSquare(i, j);
                    }
                }
            }
        }
        public void PrintBoard()
        {
            for (int i = 0; i < Matrix.Length; i++)
            {
                for (int j = 0; j < Matrix[i].Length; j++)
                {
                        Matrix[i][j].PrintOut();
                }
            }
        }
    }
}
