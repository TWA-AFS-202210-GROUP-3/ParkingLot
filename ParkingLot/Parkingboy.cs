using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private Parkinglot parkinglot;

        public ParkingBoy(Parkinglot parkinglot)
        {
            this.parkinglot = parkinglot;
        }

        public Ticket ParkCar(Car car)
        {
            return parkinglot.AddCar(car);
        }

        public Car GetCar(Ticket ticket)
        {
            return parkinglot.GetCar(ticket);
        }

        public List<Car> GetMultipleCars(List<Ticket> tickets)
        {
            return parkinglot.GetCars(tickets);
        }

        public List<Ticket> ParkMultipleCars(List<Car> cars)
        {
            return parkinglot.AddCars(cars);
        }

        public virtual Car FetchCar(Ticket ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException("Please provide your parking ticket.");
            }

            return this.parkinglot.GetCar(ticket);
        }
    }
}