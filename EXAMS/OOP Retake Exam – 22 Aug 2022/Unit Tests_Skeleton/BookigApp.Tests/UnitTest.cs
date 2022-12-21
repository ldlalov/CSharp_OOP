using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Runtime.ConstrainedExecution;

namespace BookigApp.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCreateRoom()
        {
            Room room = new Room(2, 10);
            Assert.AreEqual(2, room.BedCapacity);
            Assert.AreEqual(10, room.PricePerNight);
        }
        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void TestRoomBedCapacity(int bedCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            { Room room = new Room(bedCapacity, 1); });
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void TestRoomPricePerNight(double pricePerNight)
        {
            Assert.Throws<ArgumentException>(() =>
            { Room room = new Room(1, pricePerNight); });
        }
        [Test]
        public void TestCreateHotel()
        {
            Hotel hotel = new Hotel("Test", 5);
            Assert.AreEqual("Test", hotel.FullName);
            Assert.AreEqual(5, hotel.Category);
        }

        [Test]
        [TestCase(" ")]
        [TestCase(null)]
        public void TestHotelName(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            { Hotel hotel = new Hotel(name, 1); });
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void TestHotelCategory(int category)
        {
            Assert.Throws<ArgumentException>(() =>
            { Hotel hotel = new Hotel("someName", category); });
        }

        [Test]
        public void TestHotelAddRoom()
        {
            Hotel hotel = new Hotel("Test", 5);
            Room room = new Room(2, 10);
            hotel.AddRoom(room);
            Assert.AreEqual(1, hotel.Rooms.Count);
        }

        [Test]
        public void TestHotelBookRoom()
        {
            Hotel hotel = new Hotel("Test", 5);
            Room room = new Room(2, 10);
            hotel.AddRoom(room);
            hotel.BookRoom(1, 1, 2, 20);
            Assert.AreEqual(1, hotel.Bookings.Count);

        }
        [Test]
        [TestCase (-1)]
        [TestCase (0)]
        public void TestHotelBookRoomAdoultsWrong(int adoults)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Hotel hotel = new Hotel("Test", 5);
                Room room = new Room(2, 10);
                hotel.AddRoom(room);
                hotel.BookRoom(adoults,0, 2, 10);
            });

        }
        [Test]
        [TestCase (-1)]
        public void TestHotelBookRoomChildrenWrong(int children)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Hotel hotel = new Hotel("Test", 5);
                Room room = new Room(2, 10);
                hotel.AddRoom(room);
                hotel.BookRoom(1,children, 2, 10);
            });

        }
        [Test]
        [TestCase (-1)]
        public void TestHotelBookRoomResidenceDurationWrong(int residenceDuration)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Hotel hotel = new Hotel("Test", 5);
                Room room = new Room(2, 10);
                hotel.AddRoom(room);
                hotel.BookRoom(1,1, residenceDuration, 10);
            });

        }
        [Test]
        public void TestHotelTurnover()
        {
            Hotel hotel = new Hotel("Test", 5);
            Room room = new Room(2, 10);
            hotel.AddRoom(room);
            hotel.BookRoom(1, 1, 2, 20);
            Assert.AreEqual(20, hotel.Turnover);
        }


    }
}