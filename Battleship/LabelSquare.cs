using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class LabelSquare : Square
    {
        //MembVars

        //Constr
        public LabelSquare(int row, int col)
        {
            RowNum = row;
            ColNum = col;
        }
        //MembMeth
        public override string getPrintOutput()
        {
            string output = " ";
            if(RowNum == 0)
            {
                output += ColNum;
            }
            else
            {
                output += RowNum;
            }
            if (output.Length < 3)
            {
                output += " ";
            }
            return output;
        }
    }
}
