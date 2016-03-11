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

        private int CurrentDayId
        {
            get
            {
                return 3;
            }
        }

        public DayController(IRepository repository)
        {
            _repository = repository;
        }

        public ViewResult Schedule()
        {
            return View(
                _repository
                .Days
                .Where(p => p.DayID == CurrentDayId)
                .First());
        }
    }
}