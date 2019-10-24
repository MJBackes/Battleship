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
            //Board board = new Board();
            //board.FillBoard();
            ////board.Matrix[3][2].ChosenForPlacement = true;
            //Destroyer dest = new Destroyer(1);
            //dest.BePlaced(new int[] { 3, 4, 3, 1 }, board);
            //board.PrintBoard();
            //Player p = new Player(1);
            //p.GetShipPlacementInput();
            //Console.ReadLine();
            Game game = new Game();
            game.RunGame();
        }
    }
}
