using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicalPancakeSite.Controllers
{
    public class PagesController : Controller
    {
        public ActionResult ToDoListPage()
        {
            return View();
        }
    }
}
