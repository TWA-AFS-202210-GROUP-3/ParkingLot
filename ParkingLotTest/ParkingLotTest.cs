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
    }
}
