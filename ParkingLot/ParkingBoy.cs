namespace ParkingLot
{
    using System;
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

        public Car FetchCar(Ticket ticket)
        {
            Car aCarParked = ticket.ParkedCar;
            if (ParkingLot.ParkedCar.Contains(aCarParked))
            {
                return aCarParked;
            }

            return null;
        }
    }
}
