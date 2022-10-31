using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class NormalParkingBoy : ParkingBoyBase
    {
        public NormalParkingBoy(ParkingLot parkingLot) : base(parkingLot)
        {
        }

        public NormalParkingBoy(List<ParkingLot> parkingLots) : base(parkingLots)
        {
        }

        protected override Ticket ManageParkingLotToPark(Car car)
        {
            for (int i = 0; i < ParkingLots.Count; i++)
            {
                if (ParkingLots[i].AvailableCapacity > 0)
                {
                    ParkingLots[i].ParkedCar.Add(car);
                    ParkingLots[i].AvailableCapacity--;

                    return new Ticket(ParkingLots[i], car.CarID);
                }
            }

            return null;
        }
    }
}
