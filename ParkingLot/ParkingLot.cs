namespace ParkingLotService
{
    public class ParkingLot
    {
        public string ParkingLotNumber { get; set; }

        public ParkingLot(string parkingLotNumber)
        {
            ParkingLotNumber = parkingLotNumber;
        }
    }
}