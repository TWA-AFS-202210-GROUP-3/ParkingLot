using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace ParkingLotService
{
    public class ParkingBoy
    {
        public string ParkingBoyNumber { get; set; }

        public ParkingBoy(string parkingBoyNumber)
        {
            ParkingBoyNumber = parkingBoyNumber;
        }

        public string FetchCar(Ticket ticket)
        {
            string plate = ticket.TicketInfo.Substring(0, 7);
            return plate;
        }

        public string ParkCar(Car car, ParkingLot parkingLot)
        {
            string ticket = car.Plate + "; " + parkingLot.ParkingLotNumber + "; " + ParkingBoyNumber;
            return ticket;
        }

        public List<string> ParkCars(List<Car> cars, ParkingLot parkingLot)
        {
            var tickets = new List<string>();
            foreach (var car in cars)
            {
             string ticket = car.Plate + "; " + parkingLot.ParkingLotNumber + "; " + ParkingBoyNumber;
             tickets.Add(ticket);
            }

            return tickets;
        }

        public List<string> FetchCars(List<Ticket> tickets)
        {
            var plates = new List<string>();
            foreach (var ticket in tickets)
            {
                string plate = ticket.TicketInfo.Substring(0, 7);
                plates.Add(plate);
            }

            return plates;
        }
    }
}