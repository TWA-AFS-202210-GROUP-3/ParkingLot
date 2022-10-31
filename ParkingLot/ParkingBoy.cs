using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingBoy : ICarMethod
    {
        private List<Parkinglot> parkinglots;

        public ParkingBoy(List<Parkinglot> parkinglots)
        {
            this.parkinglots = parkinglots;
        }

        public List<Parkinglot> Parkinglots
        {
            get { return parkinglots; }
            set { parkinglots = value; }
        }

        public List<int?> Park(List<Car> carNum)
        {
            foreach (var parkinglot in Parkinglots)
            {
                List<int?> ticket = parkinglot.Park(carNum);

                if (ticket == null)
                {
                    continue;
                }

                for (int i = 0; i < ticket.Count; i++)
                {
                    var ticketItem = ticket[i];
                    if (ticketItem.HasValue)
                    {
                        return ticket;
                    }
                }
            }

            return null;
        }

        public List<Car> FetchCar(List<int?> ticket)
        {
            foreach (var parkinglot in parkinglots)
            {
                var car = parkinglot.FetchCar(ticket);

                if (car != null)
                {
                    return car;
                }
            }

            return null;
        }
    }
}
