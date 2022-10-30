namespace ParkingLotService
{
    public class Ticket
    {
        public string Plate { get; set; }
        public string ParkingLoteNumber { get; set; }
        public string ParkingBoyNumber { get; set; }
        // public string TicketInfo { get; set; }

        public Ticket(string plate, string parkingLoteNumber, string parkingBoyNumber)
        {
            Plate = plate;
            ParkingLoteNumber = parkingLoteNumber;
            ParkingBoyNumber = parkingBoyNumber;
        }
    }
}