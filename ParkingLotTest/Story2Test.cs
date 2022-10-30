using ParkingLot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class Story2Test
    {
        [Fact]
        public void Should_not_return_ticket_when_parking_lot_no_more_position()
        {
            //given
            ParkingBoy parkingBoy = new ParkingBoy();
            ParkingField parkingField = new ParkingField("parking-1", 0);
            string carId = "BJ_123456";
            //when
            string wrongNotice = parkingBoy.Park(carId, parkingField);
            //then
            Assert.Equal("Not enough position.", wrongNotice);
        }
    }
}
