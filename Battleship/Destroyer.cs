using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Destroyer : Ship
    {
        //MembVars


        //Constr
        public Destroyer(int playerNumber)
        {
            Length = 2;
            Name = "Destroyer";
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
