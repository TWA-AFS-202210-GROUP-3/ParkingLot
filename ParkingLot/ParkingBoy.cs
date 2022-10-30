using System.Collections.Generic;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private readonly string name;

        public ParkingBoy()
        {
        }

        public ParkingBoy(string name, List<ParkingField> parkingLotList)
        {
            this.name = name;
            parkingLotList.ForEach(parkingLot => BoyParkingLots.Add(parkingLot));
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string ErrorMessage { get; set; }

        public List<string> UsedTicketList { get; set; } = new List<string>();

        public List<ParkingField> BoyParkingLots { get; set; } = new List<ParkingField>();

        public string Park(string carId, ParkingField parkingField)
        {
            if (parkingField.IsFull)
            {
                return string.Empty;
            }

            string ticketNo = carId + " " + parkingField.Id;
            parkingField.ParkingCars.Add(ticketNo);
            return ticketNo;
        }

        public string Fetch(string ticketNo, ParkingField parkingField)
        {
            if (ticketNo == null || ticketNo == string.Empty)
            {
                return "Please provide your parking ticket.";
            }

            if (UsedTicketList.Contains(ticketNo))
            {
                return "Unrecognized parking ticket";
            }

            this.UsedTicketList.Add(ticketNo);
            parkingField.ParkingCars.Remove(ticketNo);
            string[] parkingInfo = ticketNo.Split(" ");
            return parkingInfo[0];
        }
    }
}