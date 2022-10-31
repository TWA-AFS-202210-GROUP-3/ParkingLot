namespace ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.ConstrainedExecution;

    public abstract class ParkingBoyBase
    {
        private List<ParkingLot> parkingLots = new List<ParkingLot>();
        public ParkingBoyBase(ParkingLot parkingLot)
        {
            this.parkingLots.Add(parkingLot);
        }

        public ParkingBoyBase(List<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots;
        }

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

            string aCarIDParked = ticket.CarID;
            for (int i = 0; i < ticket.ParkingLot.ParkedCar.Count; i++)
            {
                if (ticket.ParkingLot.ParkedCar[i].CarID == aCarIDParked)
                {
                    ticket.ParkingLot.ParkedCar.Remove(ticket.ParkingLot.ParkedCar[i]);
                    return ticket.ParkingLot.ParkedCar[i];
                }
            }

            throw new UnrecognizedTicketException("Unrecognized parking ticket.");
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

        protected virtual Ticket ManageParkingLotToPark(Car car)
        {
            return null;
        }
    }
}
