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

        public string Park(string carId, ParkingField parkingLot)
        {
            return carId + " " + parkingLot.Id;
        }

        public string Fetch(string ticketNo)
        {
            return string.Empty;
        }
    }
}