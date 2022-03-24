using NewCateringWeb.Models;
using NewCateringWeb.Models.Conetexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewCateringWeb.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Order
        public ActionResult AddPurchase()
        {
            MenuContext db = new MenuContext();
            var menu = db.Menu;
            ViewBag.Menu = menu;
            PurchaseContext context = new PurchaseContext();
            ViewBag.Name = new SelectList(context.Clients.ToList(), "ID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPurchase(Purchase model)
        {
                Purchase purchase = null;
                using (PurchaseContext db = new PurchaseContext())
                {
                    db.Purchases.Add(new Purchase {
                        Client_ID = model.Client_ID,
                        Date_Purch = DateTime.Now,
                        Deliver= model.Deliver,
                        Status_Purch = "Готовится",
                        TotalPrice = model.TotalPrice,
                        Comment = model.Comment
                    });
                    db.SaveChanges();

                    purchase = db.Purchases.Where(u => u.Client_ID == model.Client_ID && u.TotalPrice == model.TotalPrice).FirstOrDefault();
                }
                
                    // Если успещно добавлен.
                    if (purchase != null)
                    {
                        ModelState.AddModelError("", "Пользователь зарегистрирован");
                        return RedirectToAction("Orders", "Home");
                    }
            
            
            return View(model);
        }
    }
}