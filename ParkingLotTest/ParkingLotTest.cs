namespace ParkingLotTest
{
    using ParkingLot;
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
            parkingBoy.Park(cars, parkingLot);

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
            List<ParkingTicket> parkingTickets = parkingBoy.Park(cars, parkingLot);

            //when
            parkingBoy.FetchCar(parkingTickets[1], parkingLot);

            //then
            Assert.Null(parkingLot.Cars.Find(car => car.Name == parkingTickets[1].CarName));
        }
    }
}
