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
    public abstract class DayController : Controller
    {
        protected IRepository _repository;

        public DayController(IRepository repository)
        {
            _repository = repository;
        }


        public DateTime GetCurrentDate(string currentDate)
        {
            string[] CurrentDateArray = currentDate.Split(new char[] { '.' });
            int month = int.Parse(CurrentDateArray[1]);
            if (month < 1 || month > 12)
            {
                month = DateTime.Now.Month;
            }
            int year = int.Parse(CurrentDateArray[2]);
            if (year < 1900 || year > 2050)
            {
                year = DateTime.Now.Year;
            }
            int day = int.Parse(CurrentDateArray[0]);
            if (day < 1 || day > DateTime.DaysInMonth(year, month))
            {
                day = DateTime.Now.Day;
            }
            return new DateTime(year, month, day);
        }

        public abstract ViewResult Index(string date);
    }
}