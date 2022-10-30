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
            Capacity = 10;
        }

        public ParkingLot(int capacity)
        {
            Cars = new List<Car> { };
            Capacity = capacity;
        }

        public int Capacity { get; set; }

        public List<Car> Cars { get; }
        public bool AddCar(Car car)
        {
            if (Cars.Count >= 10)
            {
                return false;
            }

            Cars.Add(car);
            return true;
        }

        public bool RemoveCar(string carName)
        {
            var carFromCarName = Cars.FirstOrDefault(car => car.Name == carName);
            if (carFromCarName == null)
            {
                return false;
            }

            return Cars.Remove(carFromCarName);
        }
    }
}
