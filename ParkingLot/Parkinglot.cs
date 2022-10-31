using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Parkinglot : ICarMethod
    {
        private readonly int capacity;
        private readonly List<Car> parkedCars = new List<Car>();

        public Parkinglot(int capacity)
        {
            this.capacity = capacity;
        }

        public object AvaliableCount { get; internal set; }

        public List<Car> FetchCar(List<int?> ticket)
        {
            List<Car> cars = new List<Car>();
            for (int i = 0; i < ticket.Count; i++)
            {
                var ticketitem = ticket[i];
                var car = parkedCars.FirstOrDefault(c => c.GetHashCode() == ticketitem);
                if (car != null)
                {
                    cars.Add(car);
                    parkedCars.Remove(car);
                }
            }

            return cars;
        }

        public List<int?> Park(List<Car> carNum)
        {
            if (IsParkingLotFull())
            {
                return null;
            }

            var carCode = new List<int?>();

            for (int i = 0; i < carNum.Count; i++)
            {
                var car = carNum[i];
                parkedCars.Add(car);
                carCode.Add(car.GetHashCode());
            }

            return carCode;
        }

        private bool IsParkingLotFull()
        {
            return parkedCars.Count >= capacity;
        }
    }
}
