using System.Collections.Generic;
using System.Linq;

namespace ParkingLotService
{
    public class SmartParkingBoy : ParkingBoy
    {
        public string SmartParkingBoyId { get; set; }

        public SmartParkingBoy(string parkingBoyId) : base(parkingBoyId)
        {
            SmartParkingBoyId = parkingBoyId;
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

            var positionLeft = new List<int>();
            foreach (var parkingLot in parkingLots)
            {
                positionLeft.Add(parkingLot.Capacity - parkingLot.ParkingCars.Count);
            }

            int lotIndex = positionLeft.IndexOf(positionLeft.Max());

            return parkingLots[lotIndex];
        }

    }
}