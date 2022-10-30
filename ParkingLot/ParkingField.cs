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

        public ParkingField(string id)
        {
            this.id = id;
        }

        public string Id
        {
            get { return id; }
        }
    }
}
