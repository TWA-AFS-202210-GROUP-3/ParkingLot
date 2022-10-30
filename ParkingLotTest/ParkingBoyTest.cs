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
            var parkingBoy = new ParkingBoy("Parking Boy 01");
            var parkingLot = new ParkingLot("Parking Lot 01");
            //when
            var ticket = parkingBoy.ParkCar(car, parkingLot, parkingBoy);
            //then
            Assert.Equal("JA88888; Parking Lot 01; Parking Boy 01", ticket);
        }

        [Fact]
        public void Should_return_the_car_When_parking_boy_fetched_Given_the_parking_ticket()
        {
            //given
            var parkingBoy = new ParkingBoy("Parking Boy 01");
            var parkingLot = new ParkingLot("Parking Lot 01");
            var ticket = new Ticket("JA88888", parkingLot.ParkingLotId, parkingBoy.ParkingBoyId);
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
            var parkingBoy = new ParkingBoy("Parking Boy 01");
            var parkingLot = new ParkingLot("Parking Lot 01");
            //when
            var tickets = parkingBoy.ParkCars(cars, parkingLot, parkingBoy);
            //then
            Assert.Equal("JA00000; Parking Lot 01; Parking Boy 01", tickets[0]);
            Assert.Equal("JA66666; Parking Lot 01; Parking Boy 01", tickets[1]);
            Assert.Equal("JA88888; Parking Lot 01; Parking Boy 01", tickets[2]);
        }

        [Fact]
        public void Should_return_cars_When_parking_boy_fetched_Given_parking_tickets()
        {
            //given
            var parkingBoy = new ParkingBoy("Parking Boy 01");
            var parkingLot = new ParkingLot("Parking Lot 01");
            var tickets = new List<Ticket>()
            {
                new Ticket("JA00000", parkingLot.ParkingLotId, parkingBoy.ParkingBoyId),
                new Ticket("JA66666", parkingLot.ParkingLotId, parkingBoy.ParkingBoyId),
                new Ticket("JA88888", parkingLot.ParkingLotId, parkingBoy.ParkingBoyId),
            };
            //when
            var cars = parkingBoy.FetchCars(tickets);
            //then
            Assert.Equal("JA00000", cars[0]);
            Assert.Equal("JA66666", cars[1]);
            Assert.Equal("JA88888", cars[2]);
        }

        [Fact]
        public void Should_give_null_car_When_parking_boy_fetched_Given_null_ticket()
        {
            //given
            var parkingBoy = new ParkingBoy("Parking Boy 01");
            var parkingLot = new ParkingLot("Parking Lot 01");
            var ticket = new Ticket(null, null, null);
            //when
            var car = parkingBoy.FetchCar(null);
            //then
            Assert.Null(car);
        }

        [Fact]
        public void Should_give_null_car_When_parking_boy_fetched_Given_wrong_ticket()
        {
            //given
            var parkingBoy = new ParkingBoy("Parking Boy 01");
            var parkingLot = new ParkingLot("Parking Lot 01");
            var ticket = new Ticket("JA12345678", parkingLot.ParkingLotId, parkingBoy.ParkingBoyId);
            //when
            var response = parkingBoy.FetchCar(ticket);
            //then
            Assert.Equal("Unrecognized parking ticket.", response);
        }

        [Fact]
        public void Should_give_ticket_used_msg_When_parking_boy_fetched_Given_used_ticket()
        {
            //given
            var parkingBoy = new ParkingBoy("Parking Boy 01");
            var parkingLot = new ParkingLot("Parking Lot 01");
            var ticket = new Ticket("JA00000", parkingLot.ParkingLotId, parkingBoy.ParkingBoyId);
            //when
            var fetchCar = parkingBoy.FetchCar(ticket);
            var fetchCarAgain = parkingBoy.FetchCar(ticket);
            //then
            Assert.Equal("Unrecognized parking ticket.", fetchCarAgain);
        }

        [Fact]
        public void Should_give_null_ticket_When_parking_boy_park_the_car_Given_lot_has_no_vacancy()
        {
            //given
            var cars = new List<Car>()
            {
                new Car("JA00000"),
                new Car("JA11111"),
                new Car("JA22222"),
                new Car("JA33333"),
                new Car("JA44444"),
                new Car("JA55555"),
                new Car("JA66666"),
                new Car("JA77777"),
                new Car("JA88888"),
                new Car("JA99999"),
            };
            var parkingBoy = new ParkingBoy("Parking Boy 01");
            var parkingLot = new ParkingLot("Parking Lot 01", 10);
            var tickets = parkingBoy.ParkCars(cars, parkingLot, parkingBoy);
            var car = new Car("JA12345");
            //when
            var response = parkingBoy.ParkCar(car, parkingLot, parkingBoy);
            //then
            Assert.Equal("No vacancy.", response);
        }
    }
}
