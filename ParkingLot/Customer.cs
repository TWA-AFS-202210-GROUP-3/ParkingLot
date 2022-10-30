using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Customer
    {
        public ParkingTicket ParkingTicket { get; set; }
        public bool GetCar(ParkingBoy parkingBoy, ParkingLot parkingLot)
        {
            return parkingBoy.FetchCar(ParkingTicket, parkingLot);
        }
    }
}
