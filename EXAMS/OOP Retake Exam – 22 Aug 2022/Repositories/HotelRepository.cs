using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories
{

    public class HotelRepository : IRepository<IHotel>
    {
        private List<IHotel> hotels;
        public HotelRepository()
        {
            hotels = new List<IHotel>();
        }

        public IReadOnlyCollection<IHotel> All() => hotels;
        public IHotel Select(string hotelTypeName)
        {
            return hotels.FirstOrDefault(r => r.FullName == hotelTypeName);
        }


        void IRepository<IHotel>.AddNew(IHotel model)
        {
            hotels.Add(model);
        }

    }
}
