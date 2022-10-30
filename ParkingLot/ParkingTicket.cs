using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingTicket
    {
        public ParkingTicket(string carName)
        {
            CarName = carName;
        }

        public string CarName { get; }
    }
}
