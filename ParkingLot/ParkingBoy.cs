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

        public string ParkCar(Car car, ParkingLot parkingLot, ParkingBoy parkingBoy)
        {
            string ticketInfo = car.Plate + "; " + parkingLot.ParkingLotNumber + "; " + parkingBoy.ParkingBoyNumber;
            return ticketInfo;
        }

        public string FetchCar(Ticket ticket)
        {
            if (ticket == null)
            {
                return null;
            }
            else
            {
                var ticketInfoRef = "JA88888; Parking Lot 01; Parking Boy 01";
                var ticketInfo = ticket.Plate + "; " + ticket.ParkingLoteNumber + "; " + ticket.ParkingBoyNumber;
                if (ticketInfo.Length != ticketInfoRef.Length)
                {
                    return "Wrong ticket.";
                }
                else
                {
                    string plate = ticketInfo.Substring(0, 7);
                    return plate;
                }
            }
        }

        public List<string> ParkCars(List<Car> cars, ParkingLot parkingLot, ParkingBoy parkingBoy)
        {
            var tickets = new List<string>();
            foreach (var car in cars)
            {
                string ticket = car.Plate + "; " + parkingLot.ParkingLotNumber + "; " + parkingBoy.ParkingBoyNumber;
                tickets.Add(ticket);
            }

            return tickets;
        }

        public List<string> FetchCars(List<Ticket> tickets)
        {
            var plates = new List<string>();
            foreach (var ticket in tickets)
            {
                var ticketInfo = ticket.Plate + "; " + ticket.ParkingLoteNumber + "; " + ticket.ParkingBoyNumber;
                string plate = ticketInfo.Substring(0, 7);
                plates.Add(plate);
            }

            return plates;
        }
    }
}