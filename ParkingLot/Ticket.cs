using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Ticket
    {
        public Ticket(ParkingLot parkingLot, Car car)
        {
            ParkingLot = parkingLot;
            ParkedCar = car;
        }

        public ParkingLot ParkingLot { get; set; }
        public Car ParkedCar { get; set; }
    }
}
