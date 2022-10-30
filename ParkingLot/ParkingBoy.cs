namespace ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.ConstrainedExecution;

    public class ParkingBoy
    {
        public ParkingBoy(ParkingLot parkingLot)
        {
            ParkingLot = parkingLot;
        }

        public ParkingLot ParkingLot { get; set; }

        public Ticket ParkingCar(Car car)
        {
            if (ParkingLot.AvailableCapacity > 0)
            {
                ParkingLot.ParkedCar.Add(car);
                ParkingLot.AvailableCapacity--;

                return new Ticket(ParkingLot, car);
            }

            return null;
        }

        public List<Ticket> ParkingMultiCar(List<Car> cars)
        {
            List<Ticket> resultTickets = new List<Ticket>();
            for (int i = 0; i < cars.Count; i++)
            {
                Ticket ticket = ParkingCar(cars[i]);
                if (ticket != null)
                {
                    resultTickets.Add(ticket);
                }
                else
                {
                    return resultTickets;
                }
            }

            return resultTickets;
        }

        public Car FetchCar(Ticket ticket)
        {
            if (ticket == null)
            {
                throw new NoTicketException("Please provide your parking ticket.");
            }

            Car aCarParked = ticket.ParkedCar;
            if (ParkingLot.ParkedCar.Contains(aCarParked))
            {
                ParkingLot.ParkedCar.Remove(aCarParked);
                return aCarParked;
            }
            else
            {
                throw new UnrecognizedTicketException("Unrecognized parking ticket.");
            }
        }

        public List<Car> FetchMultiCar(List<Ticket> tickets)
        {
            List<Car> cars = new List<Car>();
            for (int i = 0; i < tickets.Count; i++)
            {
                Car car = FetchCar(tickets[i]);
                if (car != null)
                {
                    cars.Add(car);
                }
            }

            return cars;
        }
    }
}
