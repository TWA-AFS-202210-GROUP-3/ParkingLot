using ParkingLot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingCarTestForStoryFour
    {
        [Fact]
        public void Should_Parking_boy_park_car_into_parking_lot_has_more_empty_positions()
        {
            //given
            var car = new List<Car>() { new Car() };
            var parkinglot1 = new Parkinglot(10);
            var parkinglot2 = new Parkinglot(2);
            var parkingboy = new SmartParkingBoy(new List<Parkinglot>() { parkinglot1, parkinglot2 });
            //when
            var ticket = parkingboy.Park(car);
            //then
            Assert.Equal(car, parkinglot1.FetchCar(ticket));
        }
    }
}
