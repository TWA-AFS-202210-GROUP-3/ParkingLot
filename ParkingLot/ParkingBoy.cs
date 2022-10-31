using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingBoy
    {
        public ParkingBoy()
        {
            ParkingLots = new List<ParkingLot> { new ParkingLot() };
        }

        public List<ParkingLot> ParkingLots { get; set; }

        public ParkingTicket Park(Car car)
        {
            ParkingLot parkingLotNotFull;
            try
            {
                parkingLotNotFull = GetNotFullParkingLot();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (car == null || car.IsParked || GetNotFullParkingLot().Cars.Contains(car))
            {
                return null;
            }

            try
            {
                parkingLotNotFull.AddCar(car);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            car.IsParked = true;
            return new ParkingTicket(car.Name);
        }

        public List<ParkingTicket> ParkMultipleCars(List<Car> cars)
        {
            List<ParkingTicket> result = new List<ParkingTicket>();

            foreach (Car car in cars)
            {
                result.Add(Park(car));
            }

            return result;
        }

        public void FetchCar(ParkingTicket parkingTicket)
        {
            if (parkingTicket == null)
            {
                throw new Exception("Please provide your parking ticket.");
            }

            if (parkingTicket.IsUsed)
            {
                throw new Exception("Used parking ticket.");
            }

            foreach (var parkingLot in ParkingLots)
            {
                if (parkingLot.Cars.Find(car => car.Name == parkingTicket.CarName) != null)
                {
                    parkingLot.RemoveCar(parkingTicket.CarName);
                    return;
                }
            }

            throw new Exception("Car Not Found.");
        }

        public virtual ParkingLot GetNotFullParkingLot()
        {
            foreach (var parkingLot in ParkingLots)
            {
                if (!parkingLot.IsFull)
                {
                    return parkingLot;
                }
            }

            throw new Exception("Not enough position.");
        }
    }
}
