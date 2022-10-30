using ParkingLot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class Story3Test
    {
        [Fact]
        public void Should_return_ticketNo_with_2nd_parkinglot_when_given_2_parkinglots_and_first_is_full()
        {
            //given
            ParkingBoy parkingBoy = new ParkingBoy("Jack", new List<ParkingField> { new ParkingField("parking-1", 0), new ParkingField("parking-2", 2) });
            string carId = "BJ_123456";
            //when
            string ticketNo = parkingBoy.Park(carId, parkingBoy.BoyParkingLots);
            //then
            Assert.Equal("BJ_123456 parking-2", ticketNo);
        }
    }
}
