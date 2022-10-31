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
            IsFull = false;
        }

        public int Capacity { get; set; }

        public bool IsFull { get; set; }

        public List<Car> Cars { get; }
        public void AddCar(Car car)
        {
            if (IsFull)
            {
                throw new Exception("Not enough position.");
            }

            Cars.Add(car);
            IsFull = Cars.Count == 10 ? true : false;
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
