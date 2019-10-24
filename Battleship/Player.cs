﻿using System;
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
        public List<Ship> MyShips;
        public int Playernumber;
        public string Name;
        public bool HasUnplacedShips;
        public bool HasShipsAfloat;
        //Constr
        public Player(int playerNumber)
        {
            Playernumber = playerNumber;
            MyBoard = new Board();
            MyShips = new List<Ship>();
            MyDestroyer = new Destroyer(Playernumber);
            MyShips.Add(MyDestroyer);
            MySub = new Submarine(Playernumber);
            MyShips.Add(MySub);
            MyBattleship = new Battleship(Playernumber);
            MyShips.Add(MyBattleship);
            MyCarrier = new Carrier(Playernumber);
            MyShips.Add(MyCarrier);
            MyBoard.FillBoard();
            HasUnplacedShips = true;
        }
        //MembMeth
        public void SetPlayerName()
        {
            Console.WriteLine($"Player{Playernumber}: Enter your name.");
            Name = Console.ReadLine();
        }
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
        public void PlaceShip()
        {
            int[] placementInfo = GetShipPlacementInput();
            ConvertShipNumToShip(placementInfo[3]).BePlaced(placementInfo,MyBoard);
            HasUnplacedShips =  CheckIfAllShipsPlaced();
        }
        private bool CheckIfAllShipsPlaced()
        {
            foreach(Ship ship in MyShips)
            {
                if(ship.HasBeenPlaced == false)
                {
                    return true;
                }
            }
            return false;
        }
        public void CheckIfAllShipsSunk()
        {
            HasShipsAfloat = false;
            foreach (Ship ship in MyShips)
            {
                if (ship.isSunk == false)
                {
                    HasShipsAfloat = true;
                }
            }
            
        }
    }
}
