using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Parkinglot
    {
        private string name;
        private List<Ticket> tickets = new List<Ticket>();
        private List<Car> cars = new List<Car>();
        public Parkinglot(string name)
        {
            this.name = name;
        }

        public string ParkingLotName { get; set; }
        public List<Ticket> Tickets
        {
            get { return tickets; }
            set { tickets = value; }
        }

        public List<Car> Cars
        {
            get { return cars; }
        }

        public int Capacity { get; set; } = 10;

        public Ticket AddCar(Car car)
        {
            if (cars.Count < Capacity)
            {
                cars.Add(car);
                var ticket = new Ticket(car.CarName);
                tickets.Add(ticket);
                return ticket;
            }
            else
            {
                return null;
            }
        }

        public Car GetCar(Ticket ticket)
        {
            if (!tickets.Contains(ticket))
            {
                return null;
            }
            else
            {
                return cars.FindLast(car => car.CarName == ticket.CarName);
            }
        }

        public List<Ticket> AddCars(List<Car> carsInput)
        {
            int outOfCapacityCarCount = cars.Count + carsInput.Count - Capacity;
            if (outOfCapacityCarCount <= 0)
            {
                var newcars = cars.Concat(carsInput).ToList();
                cars = newcars;
                var ticketsOutput = carsInput.Select(item => new Ticket(item.CarName)).ToList();
                return ticketsOutput;
            }
            else if (outOfCapacityCarCount > 0)
            {
                carsInput.RemoveRange(carsInput.Count - outOfCapacityCarCount, outOfCapacityCarCount);
                cars.Concat(carsInput);
                List<Ticket> ticketsOutput = carsInput.Select(item => new Ticket(item.CarName)).ToList();
                return ticketsOutput.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<Car> GetCars(List<Ticket> ticketsInput)
        {
            var outPutCars = from aTicket in ticketsInput
                             from aCar in cars
                             where aCar.CarName == aTicket.CarName
                             select aCar;
            return outPutCars.ToList();
        }
    }
}