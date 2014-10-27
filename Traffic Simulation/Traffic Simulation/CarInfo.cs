using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_Simulation
{

    class CarInfo
    {
        public int id { get; private set; }
        public WhereIsNow iAmHere { get; set; }
        public int countMove { get; set; }

        public CarInfo(int id)
        {
            this.id = id;
            this.iAmHere = WhereIsNow.Beginning;
            this.countMove = -1;
        }

    }

}
