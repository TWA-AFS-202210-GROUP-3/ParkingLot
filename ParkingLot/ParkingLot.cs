using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingLot
    {
        public ParkingLot(int capacity = 10)
        {
            Capacity = capacity;
            AvailableCapacity = capacity;
            ParkedCar = new List<Car>();
        }

        public int Capacity { get; set; }

        public int AvailableCapacity { get; set; }

        public List<Car> ParkedCar { get; set; }
    }
}
