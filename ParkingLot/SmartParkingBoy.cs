using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class SmartParkingBoy : ParkingBoyBase
    {
        public SmartParkingBoy(ParkingLot parkingLot) : base(parkingLot)
        {
        }

        public SmartParkingBoy(List<ParkingLot> parkingLots) : base(parkingLots)
        {
        }

        protected override Ticket ManageParkingLotToPark(Car car)
        {
            ParkingLot haveMaxCapacityParkingLot = ParkingLots[0];
            for (int i = 1; i < ParkingLots.Count; i++)
            {
                if (ParkingLots[i].AvailableCapacity > haveMaxCapacityParkingLot.AvailableCapacity)
                {
                    haveMaxCapacityParkingLot = ParkingLots[i];
                }
            }

            if (haveMaxCapacityParkingLot.Capacity > 0)
            {
                haveMaxCapacityParkingLot.ParkedCar.Add(car);
                haveMaxCapacityParkingLot.AvailableCapacity--;

                return new Ticket(haveMaxCapacityParkingLot, car);
            }

            return null;
        }
    }
}
