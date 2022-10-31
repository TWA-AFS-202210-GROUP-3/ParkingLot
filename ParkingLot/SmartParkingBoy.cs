using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class SmartParkingBoy : ParkingBoy
    {
        public SmartParkingBoy(List<Parkinglot> parkinglots) : base(parkinglots)
        {
        }

        public new List<int?> Park(List<Car> car)
        {
            return Parkinglots.OrderByDescending(p => p.AvaliableCount).First().Park(car);
        }
    }
}
