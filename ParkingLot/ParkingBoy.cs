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

        public List<ParkingTicket> Park(List<Car> cars, ParkingLot parkingLot)
        {
            List<ParkingTicket> result = new List<ParkingTicket>();

            foreach (Car car in cars)
            {
                parkingLot.AddCar(car);
                result.Add(new ParkingTicket(car.Name));
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
