using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingBoyTest
    {
        [Fact]
        public void Should_return_a_ticket_when_parking_given_a_car()
        {
            var parkinglot = new Parkinglot("Parkinglot1");
            var parkingboy = new ParkingBoy("Jacky", parkinglot);
            var car = new Car("JJAA8888");

            var ticket = parkingboy.ParkCar(car);

            Assert.IsType<ParkingTicket>(ticket);
        }

        [Fact]
        public void Should_return_a_car_when_get_given_a_ticket()
        {
            var parkinglot = new Parkinglot("Parkinglot1");
            var parkingboy = new ParkingBoy("Jacky", parkinglot);
            var car = new Car("JJAA8888");

            var ticket = parkingboy.ParkCar(car);
            var carGet = parkingboy.GetCar(ticket);
            Assert.IsType<Car>(carGet);
        }

        [Fact]
        public void Should_return_multiple_tickets_when_get_given_multiple_cars()
        {
            var parkinglot = new Parkinglot("Parkinglot1");
            var parkingboy = new ParkingBoy("Jacky", parkinglot);
            var cars1 = new List<Car> { new Car("JJAA82388"), new Car("JJA3344887") };
            var cars = new List<Car> { new Car("JJAA8888"), new Car("JJAA8887") };
            var car = new Car("JJAA8889");
            var tickets = parkingboy.ParkMultipleCars(cars);
            var carsGet = parkingboy.GetMultipleCars(tickets);
            Assert.Equal(cars, carsGet);
        }
    }
}
