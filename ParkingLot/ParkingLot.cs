using System.Collections.Generic;

namespace ParkingLotService
{
    public class ParkingLot
    {
        public string ParkingLotId { get; set; }
        public int Capacity { get; set; }

        public ParkingLot(string parkingLotId)
        {
            ParkingLotId = parkingLotId;
        }

        public ParkingLot(string parkingLotId, int capacity)
        {
            ParkingLotId = parkingLotId;
            Capacity = capacity;
        }

        public List<string> ParkingCars { get; set; } = new List<string>();

        public bool IsFull
        {
            get { return ParkingCars.Count >= Capacity; }
        }
    }
}