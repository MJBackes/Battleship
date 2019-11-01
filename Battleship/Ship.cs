using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    abstract class Ship
    {
        //MembVars
        public int Length;
        public string Name;
       // public BoardSquare StartingSquare;
        public bool isSunk;
        //public bool SinkingHasBeenComunicated;
        public int HitsTaken;
        public List<ShipSection> Sections;
        public bool HasBeenPlaced;
        //Constr

        //MembMeth
        private int[] ConvertDirectionInputToLoopInfo(int dirInput)
        {
            switch (dirInput)
            {
                case 1:
                    return new int[] { -1, 0 };
                case 2:
                    return new int[] { 1, 0 };
                case 3:
                    return new int[] { 0, -1 };
                case 4:
                    return new int[] { 0, 1 };
                default:
                    return new int[] { 0, 0 };

            }
        }
        public bool CheckIfSunk()
        {
            foreach(ShipSection section in Sections)
            {
                if (!section.isHit)
                {
                    return false;
                }
            }
            isSunk = true;
            return true;
        }
        public void BeHit()
        {
            HitsTaken++;
            CheckIfSunk();
        }
        public void BePlaced(int[] info,Board board)
        {
            int[] direction = ConvertDirectionInputToLoopInfo(info[2]);
            int index = 0;
            while(index < Length)
            {
                board.Matrix[info[0] + direction[0] * index][info[1] + direction[1] * index].BeFilled(Sections[index]);
                index++;
            }
            HasBeenPlaced = true;
        }
    }
}
