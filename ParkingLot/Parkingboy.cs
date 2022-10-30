using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private string name;
        private Parkinglot parkinglot;

        public ParkingBoy(string name, Parkinglot parkinglot)
        {
            this.name = name;
            this.parkinglot = parkinglot;
        }

        public ParkingTicket ParkCar(Car car)
        {
            return parkinglot.AddCar(car);
        }

        public Car GetCar(ParkingTicket ticket)
        {
            return parkinglot.GetCar(ticket);
        }

        public List<Car> GetMultipleCars(List<ParkingTicket> tickets)
        {
            return parkinglot.GetCars(tickets);
        }

        public List<ParkingTicket> ParkMultipleCars(List<Car> cars)
        {
            return parkinglot.AddCars(cars);
        }
    }
}