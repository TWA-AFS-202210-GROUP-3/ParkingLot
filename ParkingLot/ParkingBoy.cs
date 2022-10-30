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

        public void FetchCar(ParkingTicket parkingTicket, ParkingLot parkingLot)
        {
            if (parkingTicket == null)
            {
                throw new Exception("Please provide your parking ticket.");
            }

            if (parkingTicket.IsUsed)
            {
                throw new Exception("Used parking ticket.");
            }

            parkingLot.RemoveCar(parkingTicket.CarName);
        }
    }
}
