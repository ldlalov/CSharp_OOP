using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IHotel> hotels;

        public Controller()
        {
            hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            IHotel hotel;
            if (hotels.Select(hotelName) != null)
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }
            hotel = new Hotel(hotelName, category);
            hotels.AddNew(hotel);
            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            if (hotels.All().FirstOrDefault(x => x.Category == category) == null)
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }
            var bestHotels = hotels.All().OrderBy(x => x.FullName);
            foreach (var hotel in bestHotels)
            {
                var bestRoom = hotel.Rooms.All().OrderBy(room => room.BedCapacity).FirstOrDefault(room => room.PricePerNight > 0 && room.BedCapacity >= adults + children && hotel.Category == category);
                if (bestRoom != null)
                {
                    int bookingNumber = hotel.Bookings.All().Count + 1;
                    IBooking booking = new Booking(bestRoom, duration, adults, children, bookingNumber);
                    hotel.Bookings.AddNew(booking);
                    return string.Format(OutputMessages.BookingSuccessful,bookingNumber,hotel.FullName);
                }
            }
                return string.Format(OutputMessages.RoomNotAppropriate);
        }

        public string HotelReport(string hotelName) 
        {
            StringBuilder sb = new StringBuilder();
            IHotel hotel = hotels.Select(hotelName);
            sb.Append($"{hotel.ToString()}");
            if (hotel.Bookings.All().Count == 0)
            {
                sb.AppendLine("none");
            }
            else
            {
                foreach (var booking in hotel.Bookings.All()) 
                {
                    sb.AppendLine(booking.BookingSummary());
                }
            }
            return sb.ToString();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            if (hotels.Select(hotelName) == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            IHotel hotel = hotels.Select(hotelName);

            if (roomTypeName != "DoubleBed" && roomTypeName != "Studio" &&roomTypeName != "Apartment")
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }
            if (hotel.Rooms.Select(roomTypeName) == null)
            {
                throw new ArgumentException(OutputMessages.RoomTypeNotCreated);
            }
            if (hotel.Rooms.Select(roomTypeName).PricePerNight!=0)
            {
                throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);
            }
                hotel.Rooms.Select(roomTypeName).SetPrice(price);
                return string.Format(OutputMessages.PriceSetSuccessfully,roomTypeName,hotelName);

        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            if (hotels.Select(hotelName) == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            IHotel hotel = hotels.Select(hotelName);
            if (hotel.Rooms.Select(roomTypeName) != default)
            {
                return String.Format(OutputMessages.RoomTypeAlreadyCreated);
            }
            //string[] roomTypes = Directory.GetFiles("..//..//..//Models//Rooms").Select(file => Path.GetFileNameWithoutExtension(file)).ToArray();

            //if (!roomTypes.Contains(roomTypeName))
            //{
            //    throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            //}

            IRoom room;
            if (roomTypeName == "DoubleBed")
            {
                room = new DoubleBed();
            }
            else if (roomTypeName == "Studio")
            {
                room = new Studio();
            }
            else if (roomTypeName == "Apartment")
            {
                room = new Apartment();
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }
            hotel.Rooms.AddNew(room);
            return String.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }
    
    }
}
