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
            var car = parkingBoy.Fetch(ticket);
            //then
            Assert.Equal("JA88888", car);
        }
    }
}
