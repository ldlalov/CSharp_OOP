using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        private int residenceDuration;
        private int adultsCount;
        private int childrenCount;
        private IRoom room;
        private int bookingNumber;
        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            Room = room;
            ResidenceDuration = residenceDuration;
            AdultsCount = adultsCount;
            ChildrenCount = childrenCount;
            BookingNumber = bookingNumber;
        }

        public IRoom Room {
            get { return room; }
                set
            { value = room; }
        }

        public int ResidenceDuration
        {
            get => residenceDuration;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.DurationZeroOrLess));
                }
                residenceDuration = value;
            }
        }

        public int AdultsCount
        {
            get => adultsCount;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.AdultsZeroOrLess));
                }
                adultsCount = value;
            }
        }

        public int ChildrenCount
        {
            get => childrenCount;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ChildrenNegative));
                }
                childrenCount = value;
            }
        }


        public int BookingNumber
        { 
            get { return bookingNumber; }
            set { bookingNumber = value; }
                
        }
        public double TotalPaid()
        {
            return Math.Round(ResidenceDuration * Room.PricePerNight, 2);
        }
        public string BookingSummary()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booking number: {BookingNumber}");
            sb.AppendLine($"Room type: {Room.GetType().Name}");
            sb.AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}");
            sb.Append($"Total amount paid: {TotalPaid():F2} $");
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
