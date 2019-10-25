using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    abstract class Square
    {
        //MembVars
        public int RowNum;
        public int ColNum;
        public bool HasBeenGuessed;
        public bool GuessWasHit;
        public bool HasShip;
        public bool ChosenForPlacement;
        public bool isMyBoard;
        public Tile MyTile;
        //Constr

        //MembMeth
        public virtual void PrintOut()
        {
            Console.Write("|_" + getPrintOutput() + "_|");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public virtual void BeFilled(Tile tile)
        {
            HasShip = true;
            MyTile = tile;
        }
        public virtual bool BeGuessed()
        {
            HasBeenGuessed = true;
            if (MyTile.GetType().ToString() == "Battleship.ShipSection")
            {
                if (!MyTile.isHit)
                {
                    MyTile.isHit = true;
                    GuessWasHit = true;
                    return true;
                }
            }
            else
            {
                MyTile.wasGuessed = true;
            }
            return false;
        
        }
        protected string GetEnemyBoardPrintout()
        {
            if (HasBeenGuessed)
            {
                if (GuessWasHit)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    return " X ";
                }
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                return " O ";
            }
            return "   ";
        }
        protected string GetMyShipsPrintout()
        {
                if (MyTile.isHit == true)
                {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                return " X ";
                }
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            return " M ";
        }
        protected string GetMyOceanTilePrintout()
        {
            if (MyTile != null)
            {
                if (MyTile.wasGuessed)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    return " O ";
                }
            }
            return "   ";
        }
        public virtual string getPrintOutput()
        {
            if (!isMyBoard)
            {
                return GetEnemyBoardPrintout();
            }
            else
            {
                if (HasShip)
                {
                    return GetMyShipsPrintout();
                }
                else if(MyTile != null && MyTile.GetType().ToString() == "Battleship.OceanTile")
                {
                   return GetMyOceanTilePrintout();
                }
                if (ChosenForPlacement)
                {
                    ChosenForPlacement = false;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    return " X ";
                }
            }
            return "   ";
        }
    }
}
