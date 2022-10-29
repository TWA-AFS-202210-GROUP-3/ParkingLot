namespace ParkingLotTest
{
    using Parking;
    using Xunit;

    public class UnitTest1
    {
        [Fact]
        public void Should_return_remove_one_ticket_And_fetch_car_when_get_car()
        {
            var parkingboy = new Parkingboy();
            var parkinglot = new Parkinglot();
            var car = new Car();

            var resultremove = parkinglot.Remove(car);
            var resultfetch = parkingboy.Fetchcar(car);

            Assert.True(resultremove);
            Assert.True(resultfetch);
        }

        [Fact]
        public void Should_return_get_ticket_And_park_car_when_parking_new_car()
        {
            var parkingboy = new Parkingboy();
            var parkinglot = new Parkinglot();
            var car = new Car();

            var resultadd = parkinglot.Add(car);
            var resultpark = parkingboy.Parkcar(car);

            Assert.True(resultadd);
            Assert.True(resultpark);
        }
    }
}
