using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class DayController : Controller
    {
        private IRepository _repository;
        private int _currentDayId;

        public int CurrentDayId
        {
            get
            {
                return 3;
            }
            set
            {
                _currentDayId = value;
            }
        }

        public DayController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public void ConfirmPeriodEnd(int periodId)
        {
            _repository.Periods.Where(p => p.PeriodId == periodId).First().IsMade = true;
        }

        public ViewResult Schedule(int dayId = 3)
        {
            return View(
                _repository
                .Days
                .Where(p => p.DayID == dayId)
                .First());
        }
    }
}