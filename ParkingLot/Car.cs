using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Car
    {
        private readonly string carName;
        public Car(string carName)
        {
            this.carName = carName;
        }

        public string CarName
        {
            get { return carName; }
        }
    }
}
