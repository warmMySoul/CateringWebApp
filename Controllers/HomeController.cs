using NewCateringWeb.Models;
using NewCateringWeb.Models.Conetexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewCateringWeb.Controllers
{
    public class HomeController : Controller
    {
        

        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Программист, Администратор, Отдел кадров")]
        public ActionResult Booker()
        {
            ViewBag.Message = "Привет Отдел Кадров.";
            

            return View();
        }
        

        PurchaseContext odb = new PurchaseContext();
        MenuContext db = new MenuContext();
        ClientContext dc = new ClientContext();
        [Authorize(Roles = "Программист, Администратор")]
        public ActionResult Orders()
        {
            var orders = odb.Purchases;
            ViewBag.Purchases = orders;
            var menu = db.Menu;
            ViewBag.Menu = menu;
            var clients = dc.Clients;
            ViewBag.Clients = clients;
            return View();
        }
    }
}