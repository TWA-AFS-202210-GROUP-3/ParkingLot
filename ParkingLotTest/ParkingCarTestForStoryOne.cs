namespace ParkingLotTest
{
    using ParkingLot;
    using System.Collections.Generic;
    using Xunit;

    public class ParkingCarTestForStoryOne
    {
        [Fact]
        public void Should_Parking_boy_park_a_car_into_parkinglot()
        {
            //given
            var car = new List<Car>() { new Car() };
            var parkinglot = new Parkinglot(2);
            var parkingboy = new ParkingBoy(new List<Parkinglot>() { parkinglot });
            //when
            var ticket = parkingboy.Park(car);
            //then
            Assert.Equal(car, parkinglot.FetchCar(ticket));
        }

        [Fact]
        public void Should_Parking_boy_fetch_a_car_with_right_ticket()
        {
            //given
            var car = new List<Car>() { new Car() };
            var parkinglot = new Parkinglot(1);
            var parkingboy = new ParkingBoy(new List<Parkinglot>() { parkinglot });
            //when
            var ticket = parkinglot.Park(car);
            //then
            Assert.Equal(car, parkingboy.FetchCar(ticket));
        }

        [Fact]
        public void Should_Parking_boy_park_multiple_cars_into_parking_lot()
        {
            //given
            var carsnum = 5;
            var carsNum = new CarsNum();
            List<Car> cars = carsNum.CarsNums(carsnum);
            var parkinglot = new Parkinglot(5);
            var parkingboy = new ParkingBoy(new List<Parkinglot>() { parkinglot });
            //when
            var ticket = parkingboy.Park(cars);
            //then
            Assert.Equal(cars, parkingboy.FetchCar(ticket));
        }

        [Fact]
        public void Should_Parking_boy_can_not_fetch_a_car_with_a_wrong_ticket()
        {
            //given
            var car1 = new List<Car>() { new Car() };
            var car2 = new List<Car>() { new Car() };
            var parkinglot = new Parkinglot(5);
            var parkingboy = new ParkingBoy(new List<Parkinglot>() { parkinglot });
            //when
            var ticket = parkinglot.Park(car1);
            //then
            Assert.NotEqual(car2, parkingboy.FetchCar(ticket));
        }

        [Fact]
        public void Should_Parking_boy_can_not_fetch_a_car_without_a_ticket()
        {
            //given
            var car = new List<Car>();
            var parkinglot = new Parkinglot(5);
            var parkingboy = new ParkingBoy(new List<Parkinglot>() { parkinglot });
            //when
            var ticket = parkinglot.Park(car);
            //then
            Assert.Empty(parkingboy.FetchCar(ticket));
        }

        [Fact]
        public void Should_Parking_boy_can_not_park_a_car_if_there_is_no_position_in_parking_lot()
        {
            //given
            var carsnum = 10;
            var carsNum = new CarsNum();
            List<Car> cars = carsNum.CarsNums(carsnum);
            var car_11 = new List<Car>() { new Car() };

            var parkinglot = new Parkinglot(10);
            var parkingboy = new ParkingBoy(new List<Parkinglot>() { parkinglot });
            //when
            parkingboy.Park(cars);
            //then
            Assert.Null(parkingboy.Park(car_11));
        }
    }
}
