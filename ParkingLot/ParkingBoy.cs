namespace ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.ConstrainedExecution;

    public class ParkingBoy
    {
        private List<ParkingLot> parkingLots = new List<ParkingLot>();
        public ParkingBoy(ParkingLot parkingLot)
        {
            this.parkingLots.Add(parkingLot);
        }

        public ParkingBoy(List<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        //public ParkingLot ParkingLot { get; set; }
        public List<ParkingLot> ParkingLots { get => parkingLots; set => parkingLots = value; }

        public Ticket ParkingCar(Car car)
        {
            if (car == null)
            {
                throw new NoCarException("No car to parking");
            }

            Ticket ticker = ManageParkingLotToPark(car);
            if (ticker == null)
            {
                throw new NotEnoughPositionException("Not enough position.");
            }

            return ticker;
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
            if (ticket.ParkingLot.ParkedCar.Contains(aCarParked))
            {
                ticket.ParkingLot.ParkedCar.Remove(aCarParked);
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

        private Ticket ManageParkingLotToPark(Car car)
        {
            for (int i = 0; i < parkingLots.Count; i++)
            {
                if (parkingLots[i].AvailableCapacity > 0)
                {
                    parkingLots[i].ParkedCar.Add(car);
                    parkingLots[i].AvailableCapacity--;

                    return new Ticket(parkingLots[i], car);
                }
            }

            return null;
        }
    }
}
