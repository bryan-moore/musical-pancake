using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicalPancakeSite.Controllers
{
    public class ToDoListController : Controller
    {
        public ActionResult ToDoListPage()
        {
            ViewBag.Message = "Hello world!";

            return View();
        }
    }
}
