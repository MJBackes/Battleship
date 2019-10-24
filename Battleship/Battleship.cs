using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Battleship : Ship
    {
        //MembVars


        //Constr
        public Battleship(int playerNumber)
        {
            Length = 4;
            Name = "Battleship";
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
