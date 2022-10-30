using System;
using System.Collections.Generic;

namespace ParkingLotService
{
    public class ParkingBoy
    {
        public string ParkingBoyId { get; set; }

        public ParkingBoy(string parkingBoyId)
        {
            ParkingBoyId = parkingBoyId;
        }

        public List<string> UsedTicketList { get; set; } = new List<string>();

        public string ParkCar(Car car, ParkingLot parkingLot, ParkingBoy parkingBoy)
        {
            if (!parkingLot.IsFull)
            {
                parkingLot.ParkingCars.Add(car.Plate);
                string ticketInfo = car.Plate + "; " + parkingLot.ParkingLotId + "; " + parkingBoy.ParkingBoyId;
                return ticketInfo;
            }
            else
            {
                return "Not enough position.";
            }
        }

        public string FetchCar(Ticket ticket)
        {
            if (ticket == null)
            {
                return "Please provide your parking ticket.";
            }
            else
            {
                var ticketInfoRef = "JA88888; Parking Lot 01; Parking Boy 01";
                var ticketInfo = ticket.Plate + "; " + ticket.ParkingLoteNumber + "; " + ticket.ParkingBoyNumber;
                if (ticketInfo.Length != ticketInfoRef.Length)
                {
                    return "Unrecognized parking ticket.";
                }
                else
                {
                    if (UsedTicketList.Contains(ticket.TicketId))
                    {
                        return "Unrecognized parking ticket.";
                    }
                    else
                    {
                        UsedTicketList.Add(ticket.TicketId);
                        string plate = ticketInfo.Substring(0, 7);
                        return plate;
                    }
                }
            }
        }

        public List<string> ParkCars(List<Car> cars, ParkingLot parkingLot, ParkingBoy parkingBoy)
        {
            var tickets = new List<string>();
            foreach (var car in cars)
            {
                parkingLot.ParkingCars.Add(car.Plate);
                string ticket = car.Plate + "; " + parkingLot.ParkingLotId + "; " + parkingBoy.ParkingBoyId;
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

        public ParkingLot ChooseParkingLot(List<ParkingLot> parkingLots)
        {
            int parkingLotId = 0;
            parkingLots.ForEach(parkingLot =>
            {
                if (parkingLot.IsFull)
                {
                    parkingLotId++;
                }
            });

            if (parkingLotId >= parkingLots.Count)
            {
                return null;
            }

            return parkingLots[parkingLotId];
        }
    }
}