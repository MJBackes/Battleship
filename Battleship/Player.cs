using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    abstract class Player
    {
        //MembVars
        public Board MyBoard;
        public Board MyEnemyBoard;
        public int BoardSize;
        public Ship MyCarrier;
        public Ship MyBattleship;
        public Ship MySub;
        public Ship MyDestroyer;
        public List<Ship> MyShips;
        public List<Ship> ShipsIveSunk;
        public int PlayerNumber;
        public string Name;
        public bool HasUnplacedShips;
        public bool HasShipsAfloat;
        //constr

        //MembMeth
        public abstract void SetPlayerName();
        public abstract int[] GetShipPlacementInput();
        public abstract int[] GetShotPlacementInfo();
        public abstract void TakeShot();
        public abstract void TakeTurn();
        protected Ship ConvertShipNumToShip(int shipNum)
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
        public void PlaceShip()
        {
            int[] placementInfo = GetShipPlacementInput();
            ConvertShipNumToShip(placementInfo[3]).BePlaced(placementInfo, MyBoard);
            HasUnplacedShips = CheckIfAnyShipsUnplaced();
        }
        private bool CheckIfAnyShipsUnplaced()
        {
            foreach (Ship ship in MyShips)
            {
                if (ship.HasBeenPlaced == false)
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
                ship.CheckIfSunk();
                if (ship.isSunk == false)
                {
                    HasShipsAfloat = true;
                }
            }

        }
        public void PrintShipsIveSunk()
        {
            if (ShipsIveSunk.Count > 0)
            {
                Console.Write("Ships I've sunk: ");
            }
            foreach (Ship ship in ShipsIveSunk)
            {
                Console.Write(ship.Name + " ");
            }
            Console.WriteLine();
        }
        public List<Ship> UpdateShipsIveSunk()
        {
            List<Ship> output = new List<Ship>();
            foreach (Ship ship in MyShips)
            {

                if (ship.CheckIfSunk())
                {
                    output.Add(ship);
                }
            }
            return output;
        }
    }
}
