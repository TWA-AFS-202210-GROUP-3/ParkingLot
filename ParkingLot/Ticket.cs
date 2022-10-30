using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Ticket
    {
        private string ticketId;
        private string carName;
        private string parkingLotName;

        public Ticket(Parkinglot parkingLot, string carName)
        {
            ticketId = Guid.NewGuid().ToString();
            this.carName = carName;
            this.parkingLotName = parkingLot.ParkingLotName;
        }

        public string CarName => carName;

        public string TicketId
        {
            get { return ticketId; }
        }

        public string ParkingLotName
        {
            get { return parkingLotName; }
        }
    }
}