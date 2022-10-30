using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotProject
{
    public class Parkingboy
    {
        private Car carShouldFetch;
        private IList<int> parkingNo;
        private int parkingNoCount;
        private int parkinglotTotal;
        private bool addResult;
        private bool removeResult;

        public Parkingboy()
        {
        }

        //public string FindrightLotNo()
        //{
        //    Parkinglot parkinglot = new Parkinglot();
        //    parkingNo = parkinglot.ParkinglotNo;
        //    parkingNoCount = parkinglot.ParkinglotNo.Count;
        //    parkinglotTotal = parkinglot.ParkinglotTotal;

        //    for (int i = 1; i < parkinglot.ParkinglotNo.Count; i++)
        //    {
        //        if (parkinglot.ParkinglotNo[i] == 0)
        //        {

        //        }
        //    }
        //    //if (parkinglotTotal == 10)
        //    //{

        //    //}
        //}

        public bool Parkcar(Car car, Ticket ticket)
        {
            ParkingLotService service = new ParkingLotService();
            addResult = service.AddOne(ticket);

            if (addResult == true)
            {
                car.GetTicket();
            }

            return true;
        }

        public bool Fetchcar(Car car, Ticket ticket)
        {
            ParkingLotService service = new ParkingLotService();
            removeResult = service.DeleteOne(ticket);

            if (removeResult == true)
            {
                car.GiveTicket();
            }

            return true;
        }
    }
}