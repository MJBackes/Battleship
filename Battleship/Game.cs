using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Game
    {
        //MembVars
        Player P1;
        Player P2;

        //Constr
        public Game()
        {

        }
        //MembMeth
        public void InstanciatePlayers()
        {
            P1 = new Player(1);
            P2 = new Player(2);
            P1.SetPlayerName();
            P2.SetPlayerName();
        } 
        private void DisplayRules()
        {
            Console.Clear();
            Console.WriteLine("Each player has 4 ships,");
            Console.WriteLine("A Destroyer(2 units long)");
            Console.WriteLine("A Submarine(3 units long)");
            Console.WriteLine("A Battleship(4 units long)");
            Console.WriteLine("A Aircraft Carrier(5 units long)");
            Console.WriteLine("Players will take turns placing a ship on their board until all ships have been placed.");
            Console.WriteLine("Then both players will take turns choosing a square on the other players board,");
            Console.WriteLine("if that square contains part of a ship, that part will be damaged.");
            Console.WriteLine("When all parts of a ship have been damaged, the ship is sunk.");
            Console.WriteLine("Play continues until one player has all their ships sunk.");
        }
        public void Start()
        {
            InstanciatePlayers();
            PlaceShips();
            EquatePlayerBoards(P1, P2);
            EquatePlayerBoards(P2, P1);
            while (P1.HasShipsAfloat && P2.HasShipsAfloat)
            {
                if (P1.HasShipsAfloat)
                {
                    P1.TakeTurn();
                }
                if (P2.HasShipsAfloat)
                {
                    P2.TakeTurn();
                }
            }

        }
        private void EquatePlayerBoards(Player p1, Player p2)
        {
            for(int i = 0; i < p1.MyBoard.Matrix.Length; i++)
            {
                for(int j = 0; j < p1.MyBoard.Matrix[i].Length; j++)
                {
                    if (p1.MyBoard.Matrix[i][j].HasShip)
                    {
                        p2.MyEnemyBoard.Matrix[i][j].BeFilled(p1.MyBoard.Matrix[i][j].ShipSec);
                    }
                }
            }
        }
        private void PlaceShips()
        {
            while(P1.HasUnplacedShips && P2.HasUnplacedShips)
            {
                P1.PlaceShip();
                P2.PlaceShip();
            }
        }
        public void RunGame()
        {
            bool continuePlaying = false;
            string input;
            do
            {
                continuePlaying = false;
                Console.Clear();
                Console.WriteLine("1:Display Rules.");
                Console.WriteLine("2:Start");
                Console.WriteLine("Enter 1 to see the rules, 2 to start.");
                input = (Console.ReadLine());
                switch (input)
                {
                    case "1":
                        DisplayRules();
                        Console.ReadLine();
                        continuePlaying = true;
                        break;
                    case "2":
                        Start();
                        break;
                    default:
                        continuePlaying = true;
                        break;
                }
                if (continuePlaying)
                {
                    continue;
                }
                do
                {
                    Console.WriteLine("Play Again? 'Y'/'N'");
                    input = Console.ReadLine().ToLower();
                } while (input != "y" && input != "n");
                if (input == "y")
                {
                    continuePlaying = true;
                }
                else
                {
                    continuePlaying = false;
                }
            } while (continuePlaying);
        }
    }
}
