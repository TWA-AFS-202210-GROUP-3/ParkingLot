namespace ParkingLotTest
{
    using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
    using ParkingLot;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class ParkingLotTest
    {
        [Fact]
        public void Should_return_a_parking_ticket_when_parking_boy_parks_a_car_into_parking_lot_given_a_car_and_a_parking_lot()
        {
            //given
            ParkingBoy parkingBoy = new ParkingBoy();
            Car car = new Car("car1");
            ParkingLot parkingLot = new ParkingLot();

            //when
            var parkingTicket = parkingBoy.Park(car, parkingLot);

            //then
            Assert.Equal(typeof(ParkingTicket), parkingTicket.GetType());
        }

        [Fact]
        public void Should_remove_car_from_parking_lot_when_parking_boy_fetch_the_car_given_a_parking_ticket()
        {
            //given
            ParkingBoy parkingBoy = new ParkingBoy();
            Car car = new Car("car1");
            ParkingLot parkingLot = new ParkingLot();
            var parkingTicket = parkingBoy.Park(car, parkingLot);

            //when
            parkingBoy.FetchCar(parkingTicket, parkingLot);

            //then
            Assert.Null(parkingLot.Cars.Find(car => car.Name == "car1"));
        }

        [Fact]
        public void Should_add_multiple_car_to_parking_lot_when_parking_boy_parks_cars_given_cars_and_a_parking_lot()
        {
            //given
            ParkingBoy parkingBoy = new ParkingBoy();
            List<Car> cars = new List<Car> { new Car("car1"), new Car("car2") };
            ParkingLot parkingLot = new ParkingLot();

            //when
            parkingBoy.ParkMultipleCars(cars, parkingLot);

            //then
            Assert.Equal(2, parkingLot.Cars.Count);
        }

        [Fact]
        public void Should_fetch_right_car_when_parking_boy_parks_multiple_cars_given_a_parking_ticket()
        {
            //given
            ParkingBoy parkingBoy = new ParkingBoy();
            List<Car> cars = new List<Car> { new Car("car1"), new Car("car2") };
            ParkingLot parkingLot = new ParkingLot();
            List<ParkingTicket> parkingTickets = parkingBoy.ParkMultipleCars(cars, parkingLot);

            //when
            parkingBoy.FetchCar(parkingTickets[1], parkingLot);

            //then
            Assert.Null(parkingLot.Cars.Find(car => car.Name == parkingTickets[1].CarName));
        }

        [Fact]
        public void Should_not_fetch_the_car_when_customer_gives_a_wrong_ticket()
        {
            //given
            ParkingBoy parkingBoy = new ParkingBoy();
            Car car = new Car("car1");
            ParkingLot parkingLot = new ParkingLot();
            Customer customer = new Customer("customerName", car);
            customer.GiveCarToPark(parkingBoy, parkingLot);
            customer.ParkingTicket = new ParkingTicket("wrong");

            //when
            customer.GetCar(parkingBoy, parkingLot);

            //then
            Assert.NotNull(parkingLot.Cars.Find(car => car.Name == "car1"));
        }

        [Fact]
        public void Should_not_fetch_the_car_when_customer_gives_no_ticket()
        {
            //given
            ParkingBoy parkingBoy = new ParkingBoy();
            Car car = new Car("car1");
            ParkingLot parkingLot = new ParkingLot();
            Customer customer = new Customer("customerName", car);
            customer.GiveCarToPark(parkingBoy, parkingLot);
            customer.ParkingTicket = null;

            //when
            //then
            Assert.Throws<Exception>(() => customer.GetCar(parkingBoy, parkingLot));
        }

        [Fact]
        public void Should_not_fetch_the_car_when_customer_gives_used_ticket()
        {
            //given
            ParkingBoy parkingBoy = new ParkingBoy();
            Car car = new Car("car1");
            ParkingLot parkingLot = new ParkingLot();
            Customer customer = new Customer("customerName", car);
            customer.GiveCarToPark(parkingBoy, parkingLot);
            customer.ParkingTicket.Use();

            //when
            //then
            Assert.Throws<Exception>(() => customer.GetCar(parkingBoy, parkingLot));
        }

        [Fact]
        public void Should_customer_get_no_ticket_when_parking_lot_is_full()
        {
            //given
            int parkingLotCapacity = 10;

            ParkingBoy parkingBoy = new ParkingBoy();
            Car car = new Car("car1");
            ParkingLot parkingLot = new ParkingLot(parkingLotCapacity);
            Customer customer = new Customer("customerName", car);

            for (int i = 0; i < parkingLotCapacity; i++)
            {
                parkingBoy.Park(new Car("car" + i.ToString()), parkingLot);
            }

            //when
            bool isSuccess = customer.GiveCarToPark(parkingBoy, parkingLot);

            //then
            Assert.False(isSuccess);
            Assert.Null(customer.ParkingTicket);
        }

        [Fact]
        public void Should_not_park_when_parking_boy_park_given_a_parked_car()
        {
            //given
            ParkingBoy parkingBoy = new ParkingBoy();
            Car car = new Car("car1");
            ParkingLot parkingLot = new ParkingLot();
            parkingBoy.Park(car, parkingLot);

            //when
            var parkingTicket = parkingBoy.Park(car, parkingLot);

            //then
            Assert.Null(parkingTicket);
        }

        [Fact]
        public void Should_not_park_when_parking_boy_park_given_a_null_car()
        {
            //given
            ParkingBoy parkingBoy = new ParkingBoy();
            ParkingLot parkingLot = new ParkingLot();

            //when
            var parkingTicket = parkingBoy.Park(null, parkingLot);

            //then
            Assert.Null(parkingTicket);
        }

        [Fact]
        public void Should_return_error_message_when_customer_get_car_given_a_null_ticket()
        {
            //given
            ParkingBoy parkingBoy = new ParkingBoy();
            Car car = new Car("car1");
            ParkingLot parkingLot = new ParkingLot();
            Customer customer = new Customer("customerName", car);
            customer.GiveCarToPark(parkingBoy, parkingLot);
            customer.ParkingTicket = null;

            //when
            //then
            Assert.Throws<Exception>(() => customer.GetCar(parkingBoy, parkingLot));
        }

        [Fact]
        public void Should_return_error_message_Please_provide_your_parking_ticket_when_customer_get_car_given_a_null_ticket()
        {
            //given
            ParkingBoy parkingBoy = new ParkingBoy();
            Car car = new Car("car1");
            ParkingLot parkingLot = new ParkingLot();
            Customer customer = new Customer("customerName", car);
            customer.GiveCarToPark(parkingBoy, parkingLot);
            customer.ParkingTicket = null;

            //when
            //then
            var exception = Assert.Throws<Exception>(() => customer.GetCar(parkingBoy, parkingLot));
            Assert.Equal("Please provide your parking ticket.", exception.Message);
        }
    }
}
