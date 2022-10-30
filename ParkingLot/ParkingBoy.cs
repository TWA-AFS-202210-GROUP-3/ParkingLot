using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingBoy
    {
        public ParkingTicket Park(Car car, ParkingLot parkingLot)
        {
            parkingLot.AddCar(car);
            return new ParkingTicket(car.Name);
        }
    }
}
