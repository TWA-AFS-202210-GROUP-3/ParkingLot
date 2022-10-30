using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingField
    {
        private readonly string id;
        private readonly int capacity = 10;

        public ParkingField(string id)
        {
            this.id = id;
        }

        public ParkingField(string id, int capacity)
        {
            this.id = id;
            this.capacity = capacity;
        }

        public int Capacity
        {
            get { return this.capacity; }
        }

        public List<string> ParkingCars { get; set; } = new List<string>();

        public string Id
        {
            get { return id; }
        }
    }
}
