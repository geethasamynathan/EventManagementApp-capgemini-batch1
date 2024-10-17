
using EventManagement_Backend.Models;
using EventManagement_Backend.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace EventManagement_Backend_Service_TestProject
{
    [TestFixture]
    public class SeatRepositoryTests
    {
        private Mock<DbSet<Seat>> _mockSet;
        private Mock<EventManagementDbContext> _mockContext;
        private SeatRepository _repository;

        [SetUp]
        public void Setup()
        {
            var seats = new List<Seat>
            {
                new Seat { SeatId = 1, EventId = 101, IsAvailble = true },
                new Seat { SeatId = 2, EventId = 101, IsAvailble = true },
                new Seat { SeatId = 3, EventId = 102, IsAvailble = false }
            }.AsQueryable();

            _mockSet = CreateDbSetMock(seats);
            _mockContext = new Mock<EventManagementDbContext>();
            _mockContext.Setup(m => m.Seats).Returns(_mockSet.Object);
            _repository = new SeatRepository(_mockContext.Object);
        }

        public static Mock<DbSet<T>> CreateDbSetMock<T>(IQueryable<T> elements) where T : class
        {
            var dbSetMock = new Mock<DbSet<T>>();
            dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(elements.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(elements.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(elements.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(elements.GetEnumerator());
            dbSetMock.Setup(m => m.Find(It.IsAny<object[]>())).Returns((object[] ids) => elements.FirstOrDefault(d => (int)d.GetType().GetProperty("SeatId").GetValue(d, null) == (int)ids[0]));
            return dbSetMock;
        }

        [Test]
        public void UpdateSeat_ShouldUpdateSeat_WhenSeatsAreAvailable()
        {
            var seatIdsToUpdate = new List<int> { 1, 2 };

            var result = _repository.UpdateSeat(101, seatIdsToUpdate);

            _mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.That(result, Is.True);
        }

        [Test]
        public void UpdateSeat_ShouldReturnFalse_WhenSeatsAreNotAvailable()
        {
            var seatIdsToUpdate = new List<int> { 3 };

            var result = _repository.UpdateSeat(101, seatIdsToUpdate);

            _mockContext.Verify(m => m.SaveChanges(), Times.Never());
            Assert.That(result, Is.False);
        }

        [Test]
        public void UpdateSeat_ShouldReturnFalse_WhenSeatsListIsEmpty()
        {
            var seatIdsToUpdate = new List<int>();

            var result = _repository.UpdateSeat(101, seatIdsToUpdate);

            _mockContext.Verify(m => m.SaveChanges(), Times.Never());
            Assert.That(result, Is.False);
        }

        [Test]
        public void UpdateSeat_ShouldReturnFalse_WhenNoSeatsWereModified()
        {
            var seatIdsToUpdate = new List<int> { 3 };

            var result = _repository.UpdateSeat(101, seatIdsToUpdate);

            _mockContext.Verify(m => m.SaveChanges(), Times.Never());
            Assert.That(result, Is.False);
        }
    }
}










//using EventManagement_Backend.Models;
//using EventManagement_Backend.Repository;
//using Microsoft.EntityFrameworkCore;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace EventManagement_Backend_Service_TestProject
//    {
//        [TestFixture]
//        public class SeatRepositoryTests
//        {
//            private Mock<DbSet<Seat>> _mockSet;
//            private Mock<EventManagementDbContext> _mockContext;
//            private SeatRepository _repository;

//            [SetUp]
//            public void Setup()
//            {
//                var seats = new List<Seat>
//            {
//                new Seat { SeatId = 1, EventId = 101, IsAvailble = true },
//                new Seat { SeatId = 2, EventId = 101, IsAvailble = true },
//                new Seat { SeatId = 3, EventId = 102, IsAvailble = false }
//            }.AsQueryable();

//                _mockSet = CreateDbSetMock(seats);
//                _mockContext = new Mock<EventManagementDbContext>();
//                _mockContext.Setup(m => m.Seats).Returns(_mockSet.Object);
//                _repository = new SeatRepository(_mockContext.Object);
//            }

//            public static Mock<DbSet<T>> CreateDbSetMock<T>(IQueryable<T> elements) where T : class
//            {
//                var dbSetMock = new Mock<DbSet<T>>();
//                dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(elements.Provider);
//                dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(elements.Expression);
//                dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(elements.ElementType);
//                dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(elements.GetEnumerator());
//                dbSetMock.Setup(m => m.Find(It.IsAny<object[]>())).Returns((object[] ids) => elements.FirstOrDefault(d => (int)d.GetType().GetProperty("SeatId").GetValue(d, null) == (int)ids[0]));
//                return dbSetMock;
//            }

//            [Test]
//            public void UpdateSeat_ShouldUpdateSeat_WhenSeatsAreAvailable()
//            {
//                var seatIdsToUpdate = new List<int> { 1, 2 };

//                var result = _repository.UpdateSeat(101, seatIdsToUpdate);

//                _mockSet.Verify(m => m.Find(It.IsAny<object[]>()), Times.Exactly(2));
//                _mockContext.Verify(m => m.SaveChanges(), Times.Once());
//                Assert.That(result, Is.True);
//            }

//            [Test]
//            public void UpdateSeat_ShouldReturnFalse_WhenSeatsAreNotAvailable()
//            {
//                var seatIdsToUpdate = new List<int> { 3 };

//                var result = _repository.UpdateSeat(101, seatIdsToUpdate);

//                _mockSet.Verify(m => m.Find(It.IsAny<object[]>()), Times.Never());
//                _mockContext.Verify(m => m.SaveChanges(), Times.Never());
//                Assert.That(result, Is.False);
//            }

//            [Test]
//            public void UpdateSeat_ShouldReturnFalse_WhenSeatsListIsEmpty()
//            {
//                var seatIdsToUpdate = new List<int>();
 
//                var result = _repository.UpdateSeat(101, seatIdsToUpdate);

//                _mockSet.Verify(m => m.Find(It.IsAny<object[]>()), Times.Never());
//                _mockContext.Verify(m => m.SaveChanges(), Times.Never());
//                Assert.That(result, Is.False);
//            }
//        }
//    }


