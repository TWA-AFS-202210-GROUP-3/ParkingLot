using System.Collections.Generic;
using System.Linq;

namespace ParkingLotService
{
    public class SmartParkingBoy : ParkingBoy
    {
        public string SmartParkingBoyId { get; set; }

        public SmartParkingBoy(string ParkingBoyId) : base(ParkingBoyId)
        {
            SmartParkingBoyId = ParkingBoyId;
        }

        public string ParkCar(Car car, List<ParkingLot> parkingLots, SmartParkingBoy smartParkingBoy)
        {
            ParkingLot parkingLot = ChooseParkingLot(parkingLots);
            return ParkCar(car, parkingLot, smartParkingBoy);
        }

        private ParkingLot ChooseParkingLot(List<ParkingLot> parkingLots)
        {
            int lotsNumber = 0;
            parkingLots.ForEach(parkingLot =>
            {
                if (parkingLot.IsFull)
                {
                    lotsNumber++;
                }
            });

            if (lotsNumber == parkingLots.Count)
            {
                return null;
            }

            // ParkingLot parkingLot = parkingLots.OrderByDescending(parkingLot => (parkingLot.Capacity - parkingLot.ParkingCars.Count)).ElementAt(0);

            var positionLeft = new List<int>();
            for (var i = 0; i < parkingLots.Count; i++)
            {
                positionLeft.Add(parkingLots[i].Capacity - parkingLots[i].ParkingCars.Count);
            }

            int lotIndex = positionLeft.IndexOf(positionLeft.Max());

            return parkingLots[lotIndex];
        }

    }
}