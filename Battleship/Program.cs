using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.FillBoard();
            //board.Matrix[3][2].ChosenForPlacement = true;
            board.PrintBoard();
            Player p = new Player(1);
            p.GetShipPlacementInput();
            Console.ReadLine();
        }
    }
}
