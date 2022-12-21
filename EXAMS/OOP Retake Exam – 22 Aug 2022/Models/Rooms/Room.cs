using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {
        private int bedCapacity;
        private double pricePerNight = 0;
        public Room(int bedCapacity)
        {
            BedCapacity = bedCapacity;
        }

        public int BedCapacity 
        { 
        get { return bedCapacity; }
            set { bedCapacity = value; }
        }

        public double PricePerNight
        {
            get => pricePerNight;
                set
            {
                if (value<0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.PricePerNightNegative));
                }
                pricePerNight = value;
            }
        }

        public void SetPrice(double price)
        {
            pricePerNight = price;
        }
    }
}
