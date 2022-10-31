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

        [Fact]
        public void Should_return_right_carId_when_fetch_car_success()
        {
            //given
            ParkingBoy parkingBoy = new ParkingBoy();
            ParkingField parkingField = new ParkingField("parking-1");
            string ticketNo = "BJ_123456 parking-1";
            //when
            string carId = parkingBoy.Fetch(ticketNo, parkingField);
            //then
            Assert.Equal("BJ_123456", carId);
        }

        [Fact]
        public void Should_show_provide_ticket_message_when_fetch_car_without_ticket()
        {
            //given
            ParkingBoy parkingBoy = new ParkingBoy();
            ParkingField parkingField = new ParkingField("parking-1");
            string ticketNo = null;
            //when
            string result = parkingBoy.Fetch(ticketNo, parkingField);
            //then
            Assert.Equal("Please provide your parking ticket.", result);
        }

        [Fact]
        public void Should_show_unrecognized_ticket_message_when_fetch_car_with_wrong_or_used_ticket()
        {
            //given
            ParkingBoy parkingBoy = new ParkingBoy();
            ParkingField parkingField = new ParkingField("parking-1");
            string carId = "BJ_123456";
            //when
            string ticketNo = parkingBoy.Park(carId, parkingField);
            parkingBoy.Fetch(ticketNo, parkingField);
            string result = parkingBoy.Fetch(ticketNo, parkingField);
            //then
            Assert.Equal("Unrecognized parking ticket", result);
        }

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
            Assert.Empty(wrongNotice);
        }
    }
}
