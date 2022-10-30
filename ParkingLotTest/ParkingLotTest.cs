namespace ParkingLotTest
{
    using ParkingLot;
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
    }
}
