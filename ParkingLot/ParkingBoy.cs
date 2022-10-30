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
            if (car == null || car.IsParked || parkingLot.Cars.Contains(car))
            {
                return null;
            }

            bool isSuccess = parkingLot.AddCar(car);
            if (!isSuccess)
            {
                return null;
            }

            car.IsParked = true;
            return new ParkingTicket(car.Name);
        }

        public List<ParkingTicket> ParkMultipleCars(List<Car> cars, ParkingLot parkingLot)
        {
            List<ParkingTicket> result = new List<ParkingTicket>();

            foreach (Car car in cars)
            {
                result.Add(Park(car, parkingLot));
            }

            return result;
        }

        public bool FetchCar(ParkingTicket parkingTicket, ParkingLot parkingLot)
        {
            if (parkingTicket == null)
            {
                return false;
            }

            if (parkingTicket.IsUsed)
            {
                return false;
            }

            return parkingLot.RemoveCar(parkingTicket.CarName);
        }
    }
}
