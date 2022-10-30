using ParkingLot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class Story4Test
    {
        [Fact]
        public void Should_return_ticketNo_when_given_2_parkinglots_which_left_1_position_and_2_position()
        {
            //given
            SmartParkingBoy smartParkingBoy = new SmartParkingBoy("Bob", new List<ParkingField> { new ParkingField("parking-1", 1), new ParkingField("parking-2", 2) });
            //when
            string ticketNo = smartParkingBoy.Park("BJ_123456", smartParkingBoy.BoyParkingLots);
            //then
            Assert.Equal("BJ_123456 parking-2", ticketNo);
        }
    }
}
