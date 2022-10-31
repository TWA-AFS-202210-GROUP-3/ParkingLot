using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLotService;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingLotTest
    {
        [Fact]
        public void Should_return_ticket_with_2nd_parking_lot_When_park_Given_1st_parking_lot_is_full()
        {
            //given
            var car = new Car("JA12345");
            var parkingBoy = new ParkingBoy("Parking Boy 01");
            var parkingLots = new List<ParkingLot>
                { new ParkingLot("Parking Lot 01", 0), new ParkingLot("Parking Lot 02", 10) };
            var parkingLot = parkingBoy.ChooseParkingLot(parkingLots);
            //when
            var ticket = parkingBoy.ParkCar(car, parkingLot, parkingBoy);
            //then
            Assert.Equal("JA12345; Parking Lot 02; Parking Boy 01", ticket);
        }
    }
}
