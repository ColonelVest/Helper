using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Abstract;
using Domain.Entities;
using System.Collections.Generic;
using WebUI.Controllers;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private Mock<IRepository> GetDayMock()
        {
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(m => m.Days).Returns(new List<Day>
            {
                new Day
                {
                    DayID = 1,
                    Periods = new List<Period>
                    {
                        new Period { PeriodId = 1, Number = 1 },
                        new Period { PeriodId = 2, Number = 2 },
                        new Period { PeriodId = 3, Number = 3 },
                        new Period { PeriodId = 4, Number = 4 },
                    }
                },
                new Day
                {
                    DayID = 2,
                    Periods = new List<Period>
                    {
                        new Period { PeriodId = 12, Number = 12 },
                        new Period { PeriodId = 21, Number = 21 },
                        new Period { PeriodId = 31, Number = 31 },
                        new Period { PeriodId = 41, Number = 41 },
                    }
                }
            });
            return mock;
        }
        [TestMethod]
        public void CanSelectDay()
        {
            DayController controller = new DayController(GetDayMock().Object);

            string date = "10.01.2010";
            Day result = (Day)controller.Index(date).Model;

            Assert.IsTrue(result.DayID == 2);
            Assert.AreEqual(result.Periods[2].PeriodId, 31);
            Assert.AreEqual(result.Periods[2].Number, 31);
        }
    }
}
