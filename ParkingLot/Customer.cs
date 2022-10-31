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

        public bool GiveCarToPark(ParkingBoy parkingBoy)
        {
            try
            {
                ParkingTicket = parkingBoy.Park(Car);
            }
            catch (Exception)
            {
                return false;
            }

            return ParkingTicket == null ? false : true;
        }

        public void GetCar(ParkingBoy parkingBoy )
        {
            try
            {
                parkingBoy.FetchCar(ParkingTicket);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
