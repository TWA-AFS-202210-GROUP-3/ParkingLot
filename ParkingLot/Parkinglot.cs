using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public class Parkinglot
    {
        public string ParkingLotNo { get; set; }
        private IList<Car> cars;
        private IList<Parkinglot> parkinglots;

        public Parkinglot(string parkinglotNo)
        {
            ParkingLotNo = parkinglotNo;
            cars = new List<Car>();
        }

        public bool Remove(Car car)
        {
            if (cars.Any(_ => _.ID == car.ID))
            {
                cars.Remove(car);
                return true;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public bool Add(Car car)
        {
            cars.Add(car);
            return false;
        }
    }
}
