namespace ParkingLotTest
{
    using ParkingLot;
    using System.Collections.Generic;
    using Xunit;

    public class ParkingLotTest
    {
        [Fact]
        public void Should_return_ticket_when_ParkingBoy_Parking_a_car()
        {
            //given
            ParkingLot parkingLot = new ParkingLot(20);
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot);
            Car aCarneedToPark = new Car();
            //when
            Ticket ticket = parkingBoy.ParkingCar(aCarneedToPark);
            //then
            Assert.NotNull(ticket);
        }

        [Fact]
        public void Should_throw_NoCarException_when_ParkingBoy_Parking_a_car()
        {
            //given
            ParkingLot parkingLot = new ParkingLot(20);
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot);
            //when
            //then
            Assert.Throws<NoCarException>(() => parkingBoy.ParkingCar(null));
        }

        [Fact]
        public void Should_throw_NotEnoughPositionException_when_ParkingBoy_Parking_a_car_while_not_enough_position()
        {
            //given
            ParkingLot parkingLot = new ParkingLot(2);
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot);
            Car aCarneedToPark1 = new Car();
            Car aCarneedToPark2 = new Car();
            Car aCarneedToPark3 = new Car();
            List<Car> cars = new List<Car>();
            cars.Add(aCarneedToPark1);
            cars.Add(aCarneedToPark2);
            List<Ticket> tickets = parkingBoy.ParkingMultiCar(cars);
            //when
            //then
            Assert.Throws<NotEnoughPositionException>(() => parkingBoy.ParkingCar(aCarneedToPark3));
        }

        [Fact]
        public void Should_return_car_when_customer_fetch_a_car_with_ticket()
        {
            //given
            ParkingLot parkingLot = new ParkingLot(20);
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot);
            Car aCarneedToPark = new Car();
            Ticket ticket = parkingBoy.ParkingCar(aCarneedToPark);
            //when
            Car aCarFetched = parkingBoy.FetchCar(ticket);
            //then
            Assert.NotNull(aCarFetched);
        }

        [Fact]
        public void Should_throw_UnrecognizedTicketException_when_customer_provide_wrong_ticket()
        {
            //given
            ParkingLot parkingLot = new ParkingLot(20);
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot);
            Car aCarneedToPark = new Car();
            Ticket ticket = parkingBoy.ParkingCar(aCarneedToPark);
            //when
            //then
            Assert.Throws<UnrecognizedTicketException>(() => parkingBoy.FetchCar(new Ticket(parkingLot, new Car())));
        }

        [Fact]
        public void Should_throw_NoTicketException_when_customer_fetch_a_car_without_ticket()
        {
            //given
            ParkingLot parkingLot = new ParkingLot(20);
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot);
            Car aCarneedToPark = new Car();
            Ticket ticket = parkingBoy.ParkingCar(aCarneedToPark);
            //when
            //then
            Assert.Throws<NoTicketException>(() => parkingBoy.FetchCar(null));
        }

        [Fact]
        public void Should_return_car_when_customer_fetch_a_car_with_ticket_already_used()
        {
            //given
            ParkingLot parkingLot = new ParkingLot(20);
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot);
            Car aCarneedToPark = new Car();
            Ticket ticket = parkingBoy.ParkingCar(aCarneedToPark);
            Car aCarFetched = parkingBoy.FetchCar(ticket);
            //when
            //then
            Assert.Throws<UnrecognizedTicketException>(() => parkingBoy.FetchCar(ticket));
        }

        [Fact]
        public void Should_return_multi_ticket_when_ParkingBoy_Parking_multi_car()
        {
            //given
            ParkingLot parkingLot = new ParkingLot(20);
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot);
            Car aCarneedToPark1 = new Car();
            Car aCarneedToPark2 = new Car();
            Car aCarneedToPark3 = new Car();
            List<Car> cars = new List<Car>();
            cars.Add(aCarneedToPark1);
            cars.Add(aCarneedToPark2);
            cars.Add(aCarneedToPark3);
            //when
            List<Ticket> tickets = parkingBoy.ParkingMultiCar(cars);
            //then
            Assert.Equal(3, tickets.Count);
        }

        [Fact]
        public void Should_return_multi_car_when_customer_fetch_multi_car_with_ticket()
        {
            //given
            ParkingLot parkingLot = new ParkingLot(20);
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot);
            Car aCarneedToPark1 = new Car();
            Car aCarneedToPark2 = new Car();
            Car aCarneedToPark3 = new Car();
            List<Car> cars = new List<Car>();
            cars.Add(aCarneedToPark1);
            cars.Add(aCarneedToPark2);
            cars.Add(aCarneedToPark3);
            List<Ticket> tickets = parkingBoy.ParkingMultiCar(cars);
            //when
            List<Car> carsFetched = parkingBoy.FetchMultiCar(tickets);
            //then

            Assert.Equal(3, carsFetched.Count);
        }
    }
}
