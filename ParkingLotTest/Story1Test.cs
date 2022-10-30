using ParkingLot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class Story1Test
    {
        [Fact]
        public void Should_return_right_ticket_when_park_car()
        {
            //given
            ParkingBoy parkingBoy = new ParkingBoy();
            ParkingField parkingLot = new ParkingField("parking-1");
            //when
            string parkingResult = parkingBoy.Park("BJ_123456", parkingLot);
            //then
            Assert.Equal("BJ_123456 parking-1", parkingResult);
        }
    }
}
