using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class ToDoListController : DayController
    {
        public ToDoListController(IRepository repository) : base(repository)
        {
        }

        public override ViewResult Index(string date)
        {
            return View("ToDoList");
        }
    }
}