using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotProject
{
    public class NoTicketException : Exception
    {
        public NoTicketException(string message) : base(message)
        {
        }
    }

    public class NoPositionException : Exception
    {
        public NoPositionException(string message) : base(message)
        {
        }
    }

    public class WrongCarException : Exception
    {
    }

    public class WrongTicketException : Exception
    {
        public WrongTicketException(string message) : base(message)
        {
        }
    }
}