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
        [TestMethod]
        public void CanSelectDay()
        {
            ScheduleController controller = new ScheduleController(GetMocks.GetDayMock().Object);

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
            ScheduleController controller = new ScheduleController(GetMocks.GetDayMock().Object);

            string date = "10.01.2010";
            DateTime result = (DateTime)controller.GetCurrentDate(date);

            DateTime dt = new DateTime(2010, 1, 10);
            Assert.AreEqual(result, dt);
        }

        [TestMethod]
        public void ConfirmingPeriodTest()
        {
            Mock<IRepository> mock = GetMocks.GetPeriodMock();
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
            Mock<IRepository> mock = GetMocks.GetPeriodMock();
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
            Mock<IRepository> mock = GetMocks.GetDayMock();
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
