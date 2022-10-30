using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotProject
{
    public class ParkingLotService
    {
        private int totalParkingLot = 10;
        private int defaultMax = 20;
        private int parkinglotNo;

        public List<Car> Parkinglots { get; set; }
        public List<Ticket> Tickets { get; set; }

        public bool AddOne(Ticket ticket)
        {
            //int parkingNoCount = ParkinglotNo.Count;
            //for (int i = 0; i < totalParkingLot; i++)
            //{
            //    if (parkingNoCount != 10)
            //    {
            //        Tickets.Add(ticket);
            //    }
            //    else
            //    {

            //    }
            //}
            if (parkinglotNo < totalParkingLot * defaultMax)
            {
                Tickets.Add(ticket);
                parkinglotNo++;
                return true;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public bool DeleteOne(Ticket ticket)
        {
            //int parkingNoCount = ParkinglotNo.Count;
            //for (int i = 0; i < totalParkingLot; i++)
            //{
            //    if (parkingNoCount != 10)
            //    {
            //        Tickets.Add(ticket);
            //    }
            //    else
            //    {

            //    }
            //}
            if (ticket.ID != null)
            {
                Tickets.Remove(ticket);
                parkinglotNo--;
                return true;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
