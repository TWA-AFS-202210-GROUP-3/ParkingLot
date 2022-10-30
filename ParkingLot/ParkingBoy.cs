using System;

namespace ParkingLotService
{
    public class ParkingBoy
    {
        public string ParkingBoyNumber { get; set; }

        public ParkingBoy(string parkingBoyNumber)
        {
            ParkingBoyNumber = parkingBoyNumber;
        }

        public string Fetch(Ticket ticket)
        {
            string plate = ticket.TicketInfo.Substring(0, 7);
            return plate;
        }

        public string ParkCar(Car car, ParkingLot parkingLot)
        {
            string ticket = car.Plate + "; " + parkingLot.ParkingLotNumber + "; " + ParkingBoyNumber;
            return ticket;
        }
    }
}