using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingTicket
    {
        private string ticketId;
        private string carName;

        public ParkingTicket(string carName)
        {
            ticketId = Guid.NewGuid().ToString();
            this.carName = carName;
        }

        public string CarName => carName;

        public string TicketId
        {
            get { return ticketId; }
        }
    }
}