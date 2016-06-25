using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ScheduleController : DayController
    {
        public ScheduleController(IRepository repository) : base(repository)
        {
        }

        private RedirectResult RedirectToView(string returnUrl)
        {
            return RedirectPermanent(returnUrl);
        }

        public RedirectResult SaveNewPeriod(Period period, int number, int dayId, string returnUrl)//прочитаю как передавать dayId и number - изменю
        {
            if (ModelState.IsValid)
            {
                period.DayId = dayId;
                period.Number = number;
                _repository.InsertPeriod(period);
            }
            return RedirectToView(returnUrl);
        }

        public RedirectResult CreateSchedule(Day day, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                _repository.AddSchedule(day);
            }
            return RedirectToView(returnUrl);
        }

        public RedirectResult ConfirmPeriodEnd(int periodId, string returnUrl)
        {

            _repository.ConfirmEndPeriod(periodId);
            return RedirectToView(returnUrl);
        }

        public override ViewResult Index(string date)
        {
            if (date == null)
            {
                date = DateTime.Now.ToShortDateString();
            }
            DateTime currentDate = GetCurrentDate(date);
            Day day = _repository.Days
                .FirstOrDefault(d => d.Date == currentDate.Date);
            if (day != null)
            {
                return View("Schedule", new ScheduleModel()
                {
                    Day = day,
                    Period = new Period()
                });
            }
            return View("EmptySchedule", new ScheduleModel()
            {
                Day = new Day()
                {
                    Periods = new List<Period>(),
                    Date = currentDate
                }
            });
        }
    }
}