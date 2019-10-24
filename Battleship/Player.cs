using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Player
    {
        //MembVars
        public Board MyBoard;
        public Ship MyCarrier;
        public Ship MyBattleship;
        public Ship MySub;
        public Ship MyDestroyer;
        public int Playernumber;
        public string Name;
        //Constr
        public Player(int playerNumber)
        {
            Playernumber = playerNumber;
            MyBoard = new Board();
            MyDestroyer = new Destroyer(Playernumber);
            MySub = new Submarine(Playernumber);
            MyBattleship = new Battleship(Playernumber);
            MyCarrier = new Carrier(Playernumber);
            MyBoard.FillBoard();
            Name = "Placeholder";
        }
        //MembMeth
        private Ship ConvertShipNumToShip(int shipNum)
        {
            switch (shipNum)
            {
                case 1:
                    return MyDestroyer;
                case 2:
                    return MySub;
                case 3:
                    return MyBattleship;
                case 4:
                    return MyCarrier;
                default:
                    return null;
            }
        }
        public int[] GetShipPlacementInput()
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
                } while (!inputIsInt || RowNum < 1 || RowNum > 20);
                do
                {
                    Console.WriteLine($"{Name}:Enter a Column number :");
                    inputIsInt = int.TryParse(Console.ReadLine(), out ColNum);
                } while (!inputIsInt || ColNum < 1 || ColNum > 20);
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
        
    }
}
