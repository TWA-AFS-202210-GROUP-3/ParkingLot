using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class SmartParkingBoy : ParkingBoy
    {
        public override ParkingLot GetNotFullParkingLot()
        {
            ParkingLot parkingLotWithMostEmpty = ParkingLots[0];
            for (int i = 1; i < ParkingLots.Count; i++)
            {
                if (ParkingLots[i].Cars.Count < parkingLotWithMostEmpty.Cars.Count)
                {
                    parkingLotWithMostEmpty = ParkingLots[i];
                }
            }

            if (parkingLotWithMostEmpty.Cars.Count == 10)
            {
                throw new Exception("Not enough position.");
            }

            return parkingLotWithMostEmpty;
        }
    }
}
