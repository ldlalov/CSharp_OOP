using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories
{
    internal class BookingRepository : IRepository<IBooking>
    {
        private List<IBooking> bookings;
        public BookingRepository()
        {
            bookings = new List<IBooking>();
        }

        public IReadOnlyCollection<IBooking> All() => bookings;
        public IBooking Select(string bookTypeName)
        {
            return bookings.FirstOrDefault(r => r.BookingNumber.ToString() == bookTypeName);
        }


        void IRepository<IBooking>.AddNew(IBooking model)
        {
            bookings.Add(model);
        }

    }
}
