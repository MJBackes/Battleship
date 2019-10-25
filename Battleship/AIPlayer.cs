using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class AIPlayer : Player
    {
        //MembVars
        private Random rng;
        private int[] LastHit;
        private int[] PreviousLastHit;
        private int[] LastGuess;
        private List<Ship> LastShipsIveSunk;
        //constr
        public AIPlayer(int playerNumber,int size)
        {
            rng = new Random();
            BoardSize = size;
            PlayerNumber = playerNumber;
            MyBoard = new Board(true,size);
            MyEnemyBoard = new Board(false,size);
            MyShips = new List<Ship>();
            ShipsIveSunk = new List<Ship>();
            LastShipsIveSunk = new List<Ship> { };
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
            LastGuess = new int[] { 0,0};
        }
        //MembMeth
        public override void SetPlayerName()
        {
            Name = "AIPlayer" + PlayerNumber;
        }
        private int generateRandomInt(int max)
        {
            return rng.Next(1, max + 1);
        }
        public override int[] GetShipPlacementInput()
        {
            int shipNum;
            int row;
            int col;
            int dir;
            do {
            shipNum = generateRandomInt(4);
            row = generateRandomInt(BoardSize);
            col = generateRandomInt(BoardSize);
            dir = generateRandomInt(4);
                } while (!MyBoard.PositionIsValid(row, col, dir, shipNum +1) || ConvertShipNumToShip(shipNum).HasBeenPlaced);
            return new int[] { row, col, dir, shipNum};
        }
        public override int[] GetShotPlacementInfo()
        {
            int row;
            int col;
            int[] dir;
            if (LastHit == null)
            {
                do
                {
                    row = generateRandomInt(BoardSize);
                    col = generateRandomInt(BoardSize);
                } while (MyEnemyBoard.Matrix[row][col].HasBeenGuessed);
                return new int[] { row, col };
            }
            else
            {
                if (PreviousLastHit == null)
                {
                    do
                    {
                        dir = MyBoard.ConvertDirectionInputToLoopInfo(generateRandomInt(4));
                        row = LastHit[0] + dir[0];
                        col = LastHit[1] + dir[1];
                    } while (row < 1 || row > BoardSize || col < 1 || col > BoardSize || MyEnemyBoard.Matrix[row][col].HasBeenGuessed);
                    return new int[] { row, col };
                }
                else
                {
                    if (LastHit[0] != LastGuess[0] || LastHit[1] != LastGuess[1])
                    {
                        if (LastHit[0] == PreviousLastHit[0])
                        {
                            row = LastHit[0];
                            col = LastHit[1];
                            col += (LastHit[1] - PreviousLastHit[1]);
                            do
                            {
                                col -= (LastHit[1] - PreviousLastHit[1]);
                                if(col > BoardSize || col < 1)
                                {
                                    LastHit = null;
                                    PreviousLastHit = null;
                                    return GetShotPlacementInfo();
                                }
                            } while (MyEnemyBoard.Matrix[row][col].HasBeenGuessed);
                        }
                        else
                        {
                            col = LastHit[1];
                            row = LastHit[0];
                            row += (LastHit[0] - PreviousLastHit[0]);
                            do
                            {
                                row -= (LastHit[0] - PreviousLastHit[0]);
                                if (row > BoardSize || row < 1)
                                {
                                    LastHit = null;
                                    PreviousLastHit = null;
                                    return GetShotPlacementInfo();
                                }
                            } while (MyEnemyBoard.Matrix[row][col].HasBeenGuessed);
                        }
                        if (col > BoardSize || col < 1 || row > BoardSize || row < 1)
                        {
                            LastHit = null;
                            PreviousLastHit = null;
                            return GetShotPlacementInfo();
                        }
                    }
                    else
                    {
                        if (LastHit[0] == PreviousLastHit[0])
                        {
                            row = LastHit[0];
                            col = LastHit[1];
                            col += (LastHit[1] - PreviousLastHit[1]);
                            if (col < 1 || col > BoardSize)
                            {
                                do
                                {
                                    col -= (LastHit[1] - PreviousLastHit[1]);
                                } while (MyEnemyBoard.Matrix[row][col].HasBeenGuessed || row < 1 || row > BoardSize
                                        || col < 1 || col > BoardSize);
                            }
                        }
                        else
                        {
                            col = LastHit[1];
                            row = LastHit[0];
                            row += (LastHit[0] - PreviousLastHit[0]);
                            if (row < 1 || row > 20)
                            {
                                do
                                {
                                    row -= (LastHit[0] - PreviousLastHit[0]);
                                } while (MyEnemyBoard.Matrix[row][col].HasBeenGuessed || row < 1 || row > BoardSize
                                        || col < 1 || col > BoardSize);
                            }
                        }
                    }
                }
            }
            return new int[] { row, col };
        }
        public override void TakeShot()
        {
            int[] info = GetShotPlacementInfo();
            bool wasHit = MyEnemyBoard.Matrix[info[0]][info[1]].BeGuessed();
            LastGuess = new int[] { info[0], info[1] };
            if (wasHit)
            {
                if (LastHit != null)
                {
                    PreviousLastHit = new int[] { LastHit[0], LastHit[1] };
                }
                LastHit = new int[] { info[0], info[1] };
            }

        }
        public override void TakeTurn()
        {
            if (checkIfISankAShip())
            {
                PreviousLastHit = null;
                LastHit = null;
            }
            TakeShot();
        }
        private bool checkIfISankAShip()
        {
            foreach(Ship ship in ShipsIveSunk)
            {
                if (!LastShipsIveSunk.Contains(ship))
                {
                    LastShipsIveSunk.Add(ship);
                    return true;
                }
            }
            return false;
        }
    }
}
