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
            Name = "Submarine";
            HitsTaken = 0;
            isSunk = false;
            Sections = new List<ShipSection>();
            for(int i = 0; i < Length; i++)
            {
                Sections.Add(new ShipSection());
            }
        }
        //MembMeth
    }
}
