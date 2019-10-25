using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class HumanPlayer : Player
    {
        //MembVars
        
        //Constr
        public HumanPlayer(int playerNumber,int size)
        {
            PlayerNumber = playerNumber;
            BoardSize = size;
            MyBoard = new Board(true,size);
            MyEnemyBoard = new Board(false,size);
            MyShips = new List<Ship>();
            ShipsIveSunk = new List<Ship>();
            MyDestroyer = new Destroyer(PlayerNumber);
            MyShips.Add(MyDestroyer);
            MySub = new Submarine(PlayerNumber);
            MyShips.Add(MySub);
            MyBattleship = new Battleship(PlayerNumber);
            MyShips.Add(MyBattleship);
            MyCarrier = new Carrier(PlayerNumber);
            MyShips.Add(MyCarrier);
            MyBoard.FillBoard();
            MyEnemyBoard.FillBoard();
            HasUnplacedShips = true;
            HasShipsAfloat = true;
        }
        //MembMeth
        public override void SetPlayerName()
        {
            Console.WriteLine($"Player{PlayerNumber}: Enter your name.");
            Name = Console.ReadLine();
        }
        
        public override int[] GetShipPlacementInput()
        {
            bool inputIsInt;
            int ColNum;
            int RowNum;
            int DirectionNum;
            int shipNum;
            Ship ship;
            bool hasLooped = false;
            do
            {
                Console.Clear();
                MyBoard.PrintBoard();
                if (hasLooped)
                {
                    Console.WriteLine("Invalid Ship Position, try again.");
                }
                do
                {
                    Console.WriteLine($"{Name}:Enter a Row number :");
                    inputIsInt = int.TryParse(Console.ReadLine(), out RowNum);
                } while (!inputIsInt || RowNum < 1 || RowNum > BoardSize);
                do
                {
                    Console.WriteLine($"{Name}:Enter a Column number :");
                    inputIsInt = int.TryParse(Console.ReadLine(), out ColNum);
                } while (!inputIsInt || ColNum < 1 || ColNum > BoardSize);
                MyBoard.Matrix[RowNum][ColNum].ChosenForPlacement = true;
                Console.Clear();
                MyBoard.PrintBoard();
                do
                {
                    do
                    {
                        Console.WriteLine($"{Name}:Enter the number of the ship you want to place: ");
                        Console.WriteLine("1:Destroyer");
                        Console.WriteLine("2:Submarine");
                        Console.WriteLine("3:Battleship");
                        Console.WriteLine("4:Aircraft Carrier");

                        inputIsInt = int.TryParse(Console.ReadLine(), out shipNum);
                    } while (!inputIsInt || shipNum < 1 || shipNum > 4);
                    ship = ConvertShipNumToShip(shipNum);
                } while (ship.HasBeenPlaced);
                do
                {
                    Console.WriteLine($"{Name}:Enter the number of an orientation: ");
                    Console.WriteLine("1:Vertical Up");
                    Console.WriteLine("2:Vertical Down");
                    Console.WriteLine("3:Horizontal Left");
                    Console.WriteLine("4:Horizontal Right");

                    
                    inputIsInt = int.TryParse(Console.ReadLine(), out DirectionNum);
                } while (!inputIsInt || DirectionNum < 1 || DirectionNum > 4);
                hasLooped = true;
            } while (!MyBoard.PositionIsValid(RowNum,ColNum,DirectionNum,shipNum +1));
            return new int[] { RowNum, ColNum, DirectionNum, shipNum };
        }
        
        
        
        
        private void ViewEnemyBoard()
        {
            bool hasCompletedTurn = false;
            string input;
            do
            {
                Console.Clear();
                MyEnemyBoard.PrintBoard();
                PrintShipsIveSunk();
                Console.WriteLine(Name);
                Console.WriteLine("1:Choose a square to shoot.");
                Console.WriteLine("2:Return to previous screen.");
                Console.WriteLine("Enter 1 to choose a square to shoot, 2 to return to the previous screen.");
                input = (Console.ReadLine());
                switch (input)
                {
                    case "1":
                        TakeShot();
                        hasCompletedTurn = true;
                        break;
                    case "2":
                        TakeTurn();
                        hasCompletedTurn = true;
                        break;
                    default:
                        hasCompletedTurn = false;
                        break;
                }
            } while (!hasCompletedTurn);
        }
        public override int[] GetShotPlacementInfo()
        {
            bool inputIsInt;
            int ColNum;
            int RowNum;
            bool hasLooped = false;
            do
            {
                Console.Clear();
                MyEnemyBoard.PrintBoard();
                if (hasLooped)
                {
                    Console.WriteLine("You already guessed that square, try again.");
                }
                do
                {
                    Console.WriteLine($"{Name}:Enter a Row number :");
                    inputIsInt = int.TryParse(Console.ReadLine(), out RowNum);
                } while (!inputIsInt || RowNum < 1 || RowNum > BoardSize);
                do
                {
                    Console.WriteLine($"{Name}:Enter a Column number :");
                    
                    
                    inputIsInt = int.TryParse(Console.ReadLine(), out ColNum);
                } while (!inputIsInt || ColNum < 1 || ColNum > BoardSize);
                hasLooped = true;
            } while (MyEnemyBoard.Matrix[RowNum][ColNum].HasBeenGuessed);
            return new int[] {RowNum, ColNum};

        }
        public override void TakeShot()
        {
            int[] info = GetShotPlacementInfo();
            bool wasHit = MyEnemyBoard.Matrix[info[0]][info[1]].BeGuessed();
            if (wasHit)
            {
                Console.WriteLine("Hit");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Miss");
                
                Console.ReadLine();
            }
        }
        public override void TakeTurn()
        {
            bool hasCompletedTurn = false;
            string input;
            do
            {
                hasCompletedTurn = false;
                Console.Clear();
                Console.WriteLine(Name);
                Console.WriteLine("1:View my board.");
                Console.WriteLine("2:View enemy board");
                Console.WriteLine("Enter 1 to look at your own board, 2 to look at the other player's board.");
                input = (Console.ReadLine());
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        MyBoard.PrintBoard();
                        Console.ReadLine();
                        hasCompletedTurn = false;
                        break;
                    case "2":
                        ViewEnemyBoard();
                        hasCompletedTurn = true;
                        break;
                    default:
                        hasCompletedTurn = false;
                        break;
                }
            } while (!hasCompletedTurn);
        }
        
    }
}
