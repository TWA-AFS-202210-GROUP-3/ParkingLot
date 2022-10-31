using System;
using System.Runtime.InteropServices.ComTypes;

namespace ParkingLotService
{
    public class Ticket
    {
        public string TicketId { get; set; }
        public string Plate { get; set; }
        public string ParkingLoteNumber { get; set; }
        public string ParkingBoyNumber { get; set; }
        // public string TicketInfo { get; set; }

        public Ticket(string plate, string parkingLoteNumber, string parkingBoyNumber)
        {
            TicketId = GenerateTicketId();
            Plate = plate;
            ParkingLoteNumber = parkingLoteNumber;
            ParkingBoyNumber = parkingBoyNumber;
        }

        public string GenerateTicketId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}