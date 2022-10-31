using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Ticket
    {
        public Ticket(ParkingLot parkingLot, string carID)
        {
            ParkingLot = parkingLot;
            CarID = carID;
        }

        public ParkingLot ParkingLot { get; set; }
        //public Car ParkedCar { get; set; }
        public string CarID { get; set; }
    }
}
