using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class UnrecognizedTicketException : Exception
    {
        public UnrecognizedTicketException(string message) : base(message)
        {
        }
    }

    public class NoTicketException : Exception
    {
        public NoTicketException(string message) : base(message)
        {
        }
    }

    public class NotEnoughPositionException : Exception
    {
        public NotEnoughPositionException(string message) : base(message)
        {
        }
    }
}
