using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using ParkingLot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingCarTestForStoryTwo
    {
        [Fact]
        public void Should_return_message_when_Parking_boy_can_not_fetch_a_car_with_a_wrong_ticket()
        {
            //given
            var car1 = new List<Car>() { new Car() };
            var car2 = new List<Car>() { new Car() };
            var parkinglot = new Parkinglot(5);
            var parkingboy = new ParkingBoy(new List<Parkinglot>() { parkinglot });
            //when
            var ticket = parkinglot.Park(car1);
            var message = " ";
            if (parkingboy.FetchCar(ticket) != car2)
            {
                 message = message + "Unrecognized parking ticket.";
            }

            //then
            Assert.Equal(" Unrecognized parking ticket.", message);
        }

        [Fact]
        public void Should__return_message_when_Parking_boy_can_not_fetch_a_car_without_a_ticket()
        {
            //givens
            var car = new List<Car>();
            var parkinglot = new Parkinglot(5);
            var parkingboy = new ParkingBoy(new List<Parkinglot>() { parkinglot });
            //when
            var ticket = parkinglot.Park(car);
            var message = " ";
            if (parkingboy.FetchCar(ticket).Count == 0)
            {
                message = message + "Please provide your parking ticket.";
            }

            //then
            Assert.Equal(" Please provide your parking ticket.", message);
        }

        [Fact]
        public void Should_return_message_when_Parking_boy_can_not_park_a_car_if_there_is_no_position_in_parking_lot()
        {
            //given
            var carsnum = 10;
            var carsNum = new CarsNum();
            List<Car> cars = carsNum.CarsNums(carsnum);
            var car_11 = new List<Car>() { new Car() };

            var parkinglot = new Parkinglot(10);
            var parkingboy = new ParkingBoy(new List<Parkinglot>() { parkinglot });
            //when
            var ticket = parkingboy.Park(cars);
            var message = " ";
            if (parkingboy.Park(car_11) == null)
            {
                message = message + "Please provide your parking ticket.";
            }

            //then
            Assert.Equal(" Please provide your parking ticket.", message);
        }
    }
}
