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
            ParkingBoyBase parkingBoy = new ParkingBoyBase(parkingLot);
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
            ParkingBoyBase parkingBoy = new ParkingBoyBase(parkingLot);
            //when
            //then
            Assert.Throws<NoCarException>(() => parkingBoy.ParkingCar(null));
        }

        [Fact]
        public void Should_throw_NotEnoughPositionException_when_ParkingBoy_Parking_a_car_while_not_enough_position()
        {
            //given
            ParkingLot parkingLot = new ParkingLot(2);
            ParkingBoyBase parkingBoy = new ParkingBoyBase(parkingLot);
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
            ParkingBoyBase parkingBoy = new ParkingBoyBase(parkingLot);
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
            ParkingBoyBase parkingBoy = new ParkingBoyBase(parkingLot);
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
            ParkingBoyBase parkingBoy = new ParkingBoyBase(parkingLot);
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
            ParkingBoyBase parkingBoy = new ParkingBoyBase(parkingLot);
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
            ParkingBoyBase parkingBoy = new ParkingBoyBase(parkingLot);
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
            ParkingBoyBase parkingBoy = new ParkingBoyBase(parkingLot);
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

        [Fact]
        public void Should_return_one_ticket_For_parkingLot2_when_ParkingBoy_Parking_multi_car_and_the_first_parkingLot_is_full()
        {
            //given
            ParkingLot parkingLot1 = new ParkingLot(2);
            ParkingLot parkingLot2 = new ParkingLot(2);
            List<ParkingLot> parkingLots = new List<ParkingLot>();
            parkingLots.Add(parkingLot1);
            parkingLots.Add(parkingLot2);
            ParkingBoyBase parkingBoy = new ParkingBoyBase(parkingLots);
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
            Assert.Equal(parkingLot2, tickets[2].ParkingLot);
        }

        [Fact]
        public void Should_return_all_ticket_For_parkingLot1_when_ParkingBoy_Parking_multi_car_and_the_first_parkingLot_is_not_full()
        {
            //given
            ParkingLot parkingLot1 = new ParkingLot(4);
            ParkingLot parkingLot2 = new ParkingLot(2);
            List<ParkingLot> parkingLots = new List<ParkingLot>();
            parkingLots.Add(parkingLot1);
            parkingLots.Add(parkingLot2);
            ParkingBoyBase parkingBoy = new ParkingBoyBase(parkingLots);
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
            Assert.Equal(parkingLot1, tickets[2].ParkingLot);
        }

        [Fact]
        public void Should_return_ticket_For_parkingLot2_when_ParkingBoy_Parking_car_and_the_second_parkingLot_have_more_available_capacity()
        {
            //given
            ParkingLot parkingLot1 = new ParkingLot(4);
            ParkingLot parkingLot2 = new ParkingLot(10);
            List<ParkingLot> parkingLots = new List<ParkingLot>();
            parkingLots.Add(parkingLot1);
            parkingLots.Add(parkingLot2);
            SmartParkingBoy parkingBoy = new SmartParkingBoy(parkingLots);
            Car aCarneedToPark1 = new Car();
            //when
            Ticket tickets = parkingBoy.ParkingCar(aCarneedToPark1);
            //then
            Assert.Equal(parkingLot2, tickets.ParkingLot);
        }
    }
}
