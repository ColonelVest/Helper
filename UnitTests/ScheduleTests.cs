using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Abstract;
using Domain.Entities;
using System.Collections.Generic;
using WebUI.Controllers;
using WebUI.Models;
using System.Web.Mvc;

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
        public void GettingCurrentDateTest()
        {
            ScheduleController controller = new ScheduleController(GetDayMock().Object);

            string date = "10.01.2010";
            DateTime result = (DateTime)controller.GetCurrentDate(date);

            DateTime dt = new DateTime(2010, 1, 10);
            Assert.AreEqual(result, dt);
        }

        [TestMethod]
        public void ConfirmingPeriodTest()
        {
            Mock<IRepository> mock = GetPeriodMock();
            ScheduleController controller = new ScheduleController(mock.Object);

            int periodId = 2;
            string url = "/schedule/index";
            RedirectResult result = controller.ConfirmPeriodEnd(periodId, url);

            mock.Verify(m => m.ConfirmEndPeriod(periodId));

            Assert.IsTrue(result.Permanent);
            Assert.AreEqual("/schedule/index", result.Url);
        }

        [TestMethod]
        public void SavingNewPeriodTest()
        {
            Mock<IRepository> mock = GetPeriodMock();
            ScheduleController controller = new ScheduleController(mock.Object);

            int dayId = 2;
            string url = "/";
            int number = 2;
            Period period = new Period()
            {
                Description = "sdfsadfd",
                Duration = 32
            };
            RedirectResult result = controller.SaveNewPeriod(period, number, dayId, url);

            mock.Verify(m => m.InsertPeriod(period));

            Assert.IsTrue(result.Permanent);
            Assert.AreEqual("/", result.Url);
        }

        [TestMethod]
        public void CreatingScheduleTest()
        {
            Mock<IRepository> mock = GetDayMock();
            ScheduleController controller = new ScheduleController(mock.Object);

            string url = "/";
            Day day = new Day();
            RedirectResult result = controller.CreateSchedule(day, url);

            mock.Verify(m => m.AddSchedule(day));

            Assert.IsTrue(result.Permanent);
            Assert.AreEqual("/", result.Url);
        }
    }
}
