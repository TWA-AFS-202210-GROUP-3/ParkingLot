using System.Collections.Generic;

namespace ParkingLotTest
{
    using ParkingLotService;
    using Xunit;

    public class ParkingBoyTest
    {
        [Fact]
        public void Should_return_the_parking_ticket_When_parking_boy_parked_Given_the_car()
        {
            //given
            var car = new Car("JA88888");
            var parkingBoy = new ParkingBoy("Parking Boy 1");
            var parkingLot = new ParkingLot("Parking Lot 1");
            //when
            var ticket = parkingBoy.ParkCar(car, parkingLot);
            //then
            Assert.Equal("JA88888; Parking Lot 1; Parking Boy 1", ticket);
        }

        [Fact]
        public void Should_return_the_car_When_parking_boy_fetched_Given_the_parking_ticket()
        {
            //given
            var ticket = new Ticket("JA88888; Parking Lot 1; Parking Boy 1");
            var parkingBoy = new ParkingBoy("Parking Boy 1");
            var parkingLot = new ParkingLot("Parking Lot 1");
            //when
            var car = parkingBoy.FetchCar(ticket);
            //then
            Assert.Equal("JA88888", car);
        }

        [Fact]
        public void Should_return_parking_tickets_When_parking_boy_parked_Given_cars()
        {
            //given
            var cars = new List<Car>()
            {
                new Car("JA00000"),
                new Car("JA66666"),
                new Car("JA88888"),
            };
            var parkingBoy = new ParkingBoy("Parking Boy 1");
            var parkingLot = new ParkingLot("Parking Lot 1");
            //when
            var tickets = parkingBoy.ParkCars(cars, parkingLot);
            //then
            Assert.Equal("JA00000; Parking Lot 1; Parking Boy 1", tickets[0]);
            Assert.Equal("JA66666; Parking Lot 1; Parking Boy 1", tickets[1]);
            Assert.Equal("JA88888; Parking Lot 1; Parking Boy 1", tickets[2]);
        }

        [Fact]
        public void Should_return_cars_When_parking_boy_fetched_Given_parking_tickets()
        {
            //given
            var tickets = new List<Ticket>()
            {
                new Ticket("JA00000; Parking Lot 1; Parking Boy 1"),
                new Ticket("JA66666; Parking Lot 1; Parking Boy 1"),
                new Ticket("JA88888; Parking Lot 1; Parking Boy 1"),
            };
            var parkingBoy = new ParkingBoy("Parking Boy 1");
            var parkingLot = new ParkingLot("Parking Lot 1");
            //when
            var cars = parkingBoy.FetchCars(tickets);
            //then
            Assert.Equal("JA00000", cars[0]);
            Assert.Equal("JA66666", cars[1]);
            Assert.Equal("JA88888", cars[2]);
        }
    }
}
