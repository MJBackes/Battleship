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
        public Square[][] Matrix;
        public bool isMyBoard;
        public int Size;
        //Constr
        public Board(bool isMine, int size)
        {
            isMyBoard = isMine;
            Size = size;
            Matrix = new Square[size + 1][];
            for(int i = 0; i < Matrix.Length; i++)
            {
                Matrix[i] = new Square[size + 1];
            }
        }
        //MembMeth
        public void FillBoard()
        {
            for(int i = 0; i < Matrix.Length; i++)
            {
                for(int j = 0; j < Matrix[i].Length; j++)
                {
                    if ((i == 0 || j == 0) && i != j)
                    {
                        Matrix[i][j] = new LabelSquare(i, j);
                    }
                    else
                    {
                        Matrix[i][j] = new BoardSquare(i, j, isMyBoard);
                    }
                }
            }
        }
        public void FillWithOceanTiles()
        {
            for(int i = 0; i < Matrix.Length; i++)
            {
                for(int j = 0; j < Matrix[i].Length; j++)
                {
                    if (!Matrix[i][j].HasShip)
                    {
                        Matrix[i][j].MyTile = new OceanTile();
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
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }
        }
        public int[] ConvertDirectionInputToLoopInfo(int dirInput)
        {
            switch (dirInput)
            {
                case 1:
                    return new int[] { -1, 0};
                case 2:
                    return new int[] { 1, 0};
                case 3:
                    return new int[] { 0, -1};
                case 4:
                    return new int[] { 0, 1};
                default:
                    return new int[] { 0, 0};

            }
        }
        public bool PositionIsValid(int row, int col, int dir,int shipLength)
        {
            ///
            int[] loopInfo = ConvertDirectionInputToLoopInfo(dir);
            if(row + (loopInfo[0] * (shipLength - 1)) > Size || row + (loopInfo[0] * (shipLength - 1)) < 1 
                || col + (loopInfo[1] * (shipLength - 1)) > Size || col + (loopInfo[1] * (shipLength - 1)) < 1)
            {
                return false;
            }
            int index = 0;
            while (index < shipLength)
            {
                if (Matrix[row + loopInfo[0] * index][col + loopInfo[1] * index].HasShip)
                {
                    return false;
                }
                index++;
            }
            return true;
        }
    }
}
