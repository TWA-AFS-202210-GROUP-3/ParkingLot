using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class SmartParkingBoy : ParkingBoy
    {
        public SmartParkingBoy(string name, List<ParkingField> parkingFields) : base(name, parkingFields)
        {
        }

        public string Park(string carId, List<ParkingField> parkingFields)
        {
            ParkingField parkingField = ChooseParkingField(parkingFields);
            return Park(carId, parkingField);
        }

        private ParkingField ChooseParkingField(List<ParkingField> parkingFields)
        {
            int fullFieldsNum = 0;
            parkingFields.ForEach(field =>
            {
               if (field.IsFull)
                {
                    fullFieldsNum++;
                }
            });

            if (fullFieldsNum == parkingFields.Count)
            {
                return null;
            }

            ParkingField parkingField = parkingFields.OrderByDescending(parkingField => parkingField.PositionLeft).ElementAt(0);
            return parkingField;
        }
    }
}
