
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class SmartParkingBoy : ParkingBoy
    {
        private List<Parkinglot> parkingLots;

        public SmartParkingBoy(List<Parkinglot> parkingLots, Parkinglot parkingLot) : base(parkingLot)
        {
            this.parkingLots = parkingLots;
        }

        public override Car FetchCar(Ticket ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException("Please provide your parking ticket.");
            }

            var storageParkingLot = parkingLots[0];

            for (int i = 0; i < parkingLots.Count; i++)
            {
                if (parkingLots[i].ParkingLotName == ticket.ParkingLotName)
                {
                    storageParkingLot = parkingLots[i];
                }
            }

            // var storageParkingLot = parkingLots.Where(_ => _.ParkingLotName == ticket.ParkingLotName);
            return storageParkingLot.GetCar(ticket);
        }

        public Ticket ParkingCar(Car car)
        {
            var storageParkingLot = parkingLots[0];

            for (int i = 0; i < parkingLots.Count; i++)
            {
                if (parkingLots[i].Capacity > 0)
                {
                    storageParkingLot = parkingLots[i];
                }
            }

            return storageParkingLot.AddCar(car);
        }
    }
}
