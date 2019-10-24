using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Carrier : Ship
    {
        //MembVars


        //Constr
        public Carrier(int playerNumber)
        {
            Length = 5;
            Name = "Aircraft Carrier";
            HitsTaken = 0;
            isSunk = false;
            Sections = new List<ShipSection>();
            for (int i = 0; i < Length; i++)
            {
                Sections.Add(new ShipSection());
            }
        }
        //MembMeth
    }
}
