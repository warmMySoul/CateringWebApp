using NewCateringWeb.Models;
using NewCateringWeb.Models.Conetexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewCateringWeb.Controllers
{
    public class ClientController : Controller
    {
        // GET: Register client.
        [Authorize(Roles = "Программист, Администратор, Продавец")]
        public ActionResult RegisterClient()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterClient(Client model)
        {
            if (ModelState.IsValid)
            {
                Client client = null;
                using (ClientContext db = new ClientContext())
                {
                    client = db.Clients.FirstOrDefault(u => u.Telephone == model.Telephone);
                }
                if (client == null)
                {
                    // Создаем нового пользователя.
                    using (ClientContext db = new ClientContext())
                    {
                        if (model.Name == null || model.Telephone == null || model.Name == "" || model.Telephone == "")
                        {
                            ModelState.AddModelError("", "Неправельно заполнены поля логина и пароля");
                        }
                        else
                        {
                            db.Clients.Add(new Client { Name = model.Name, Telephone = model.Telephone, Index = model.Index });
                            db.SaveChanges();
                        }


                        client = db.Clients.Where(u => u.Name == model.Name && u.Telephone == model.Telephone).FirstOrDefault();
                    }
                    // Если успещно добавлен.
                    if (client != null)
                    {
                        ModelState.AddModelError("","Клиент успешно добавлен.");
                        return RedirectToAction("Orders", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }
            return View(model);
        }
    }
}