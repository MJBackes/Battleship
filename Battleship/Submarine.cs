using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Submarine : Ship
    {
        //MembVars


        //Constr
        public Submarine(int playerNumber)
        {
            Length = 3;
            HitsTaken = 0;
            isSunk = false;
            Sections = new List<ShipSection>();
            if (playerNumber == 1)
            {
                IsOwnedByP1 = true;
                isOwnedByP2 = false;
            }
            else
            {
                IsOwnedByP1 = false;
                isOwnedByP2 = true;
            }
            for(int i = 0; i < Length; i++)
            {
                Sections.Add(new ShipSection());
            }
        }
        //MembMeth
    }
}
