using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingLot
    {
        public ParkingLot()
        {
            Cars = new List<Car> { };
        }

        public List<Car> Cars { get; }
        public void AddCar(Car car)
        {
            Cars.Add(car);
        }
    }
}
