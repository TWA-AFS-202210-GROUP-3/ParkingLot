using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingTicket
    {
        public ParkingTicket(string carName)
        {
            CarName = carName;
            IsUsed = false;
        }

        public bool IsUsed { get; set; }

        public string CarName { get; }

        public void Use()
        {
            if (IsUsed)
            {
                throw new InvalidOperationException("The ticket is already used");
            }

            IsUsed = true;
        }
    }
}
