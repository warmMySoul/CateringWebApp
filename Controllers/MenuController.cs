using NewCateringWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewCateringWeb.Controllers
{
    public class MenuController : Controller
    {
        MenuContext db = new MenuContext();

        // GET: Menu
        public ActionResult Menu()
        {
            var menu = db.Menu;
            ViewBag.Menu = menu;
            return View();
        }
    }
}