using ParkingLotService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class SmartParkingBoyTest
    {
        [Fact]
        public void Should_return_ticket_with_more_vacancy_parking_lot_When_park_Given_2_parking_lot_with_2nd_has_more_vacancy()
        {
            //given
            var car = new Car("JA12345");
            var smartParkingBoy = new SmartParkingBoy("Parking Boy S1");
            var parkingLots = new List<ParkingLot>
                { new ParkingLot("Parking Lot 01", 2), new ParkingLot("Parking Lot 02", 10) };
            //when
            var ticket = smartParkingBoy.ParkCar(car, parkingLots, smartParkingBoy);
            //then
            Assert.Equal("JA12345; Parking Lot 02; Parking Boy S1", ticket);
        }
    }
}
