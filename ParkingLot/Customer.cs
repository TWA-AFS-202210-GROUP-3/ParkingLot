using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Customer
    {
        public Customer(string name, Car car)
        {
            Name = name;
            Car = car;
        }

        public string Name { get; set; }
        public ParkingTicket ParkingTicket { get; set; }
        public Car Car { get; set; }

        public bool GiveCarToPark(ParkingBoy parkingBoy, ParkingLot parkingLot)
        {
            ParkingTicket = parkingBoy.Park(Car, parkingLot);
            return ParkingTicket == null ? false : true;
        }

        public void GetCar(ParkingBoy parkingBoy, ParkingLot parkingLot)
        {
            try
            {
                parkingBoy.FetchCar(ParkingTicket, parkingLot);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
