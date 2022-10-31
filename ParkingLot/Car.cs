using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Car
    {
        public Car(string carID)
        {
            CarID = carID;
        }

        public string CarID { get; set; }
    }
}
