using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Abstract;
using Domain.Entities;
using System.Collections.Generic;
using WebUI.Controllers;
using WebUI.Models;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private Mock<IRepository> GetPeriodMock()
        {
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(m => m.Periods).Returns(new List<Period>
            {
                new Period { PeriodId = 1, Number = 1, IsMade = false },
                new Period { PeriodId = 2, Number = 2, IsMade = true },
                new Period { PeriodId = 3, Number = 3, IsMade = false },
                new Period { PeriodId = 4, Number = 4, IsMade = true },
                new Period { PeriodId = 12, Number = 12, IsMade = true },
                new Period { PeriodId = 21, Number = 21, IsMade = false },
                new Period { PeriodId = 31, Number = 31, IsMade = false },
                new Period { PeriodId = 41, Number = 41, IsMade = true }
            });
            return mock;
        }

        private Mock<IRepository> GetDayMock()
        {
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(m => m.Days).Returns(new List<Day>
            {
                new Day
                {
                    DayID = 1,
                    Date = new DateTime(2010, 1, 10),
                    Periods = new List<Period>
                    {
                        new Period { PeriodId = 1, Number = 1, IsMade = false },
                        new Period { PeriodId = 2, Number = 2, IsMade = true },
                        new Period { PeriodId = 3, Number = 3, IsMade = false },
                        new Period { PeriodId = 4, Number = 4, IsMade = true }
                    }
                },
                new Day
                {
                    DayID = 2,
                    Date = new DateTime(2016, 3, 17),
                    Periods = new List<Period>
                    {
                        new Period { PeriodId = 12, Number = 12, IsMade = true },
                        new Period { PeriodId = 21, Number = 21, IsMade = false },
                        new Period { PeriodId = 31, Number = 31, IsMade = false },
                        new Period { PeriodId = 41, Number = 41, IsMade = true }
                    }
                }
            });
            return mock;
        }
        [TestMethod]
        public void CanSelectDay()
        {
            ScheduleController controller = new ScheduleController(GetDayMock().Object);

            string date = "10.01.2010";
            ScheduleModel result = (ScheduleModel)controller.Index(date).Model;

            Day day = result.Day;
            Assert.IsTrue(result.Day.DayID == 1);
            Assert.AreEqual(result.Day.Periods[2].PeriodId, 3);
            Assert.AreEqual(result.Day.Periods[2].Number, 3);
        }

        [TestMethod]
        public void GetCurrentDateTest()
        {
            ScheduleController controller = new ScheduleController(GetDayMock().Object);

            string date = "10.01.2010";
            DateTime result = (DateTime)controller.GetCurrentDate(date);

            DateTime dt = new DateTime(2010, 1, 10);
            Assert.AreEqual(result, dt);
        }

    }
}
