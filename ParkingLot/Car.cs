using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Car
    {
        public Car(string name)
        {
            Name = name;
            IsParked = false;
        }

        public bool IsParked { get; set; }

        public string Name { get; }
    }
}
