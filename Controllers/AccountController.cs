using NewCateringWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NewCateringWeb.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login Account.
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // Поиск в бд.
                User user = null;
                using (UserContext db = new UserContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Login == model.Login && u.Password == model.Password);
                }
                if (user != null)
                {
                    // Отправляем на главную.
                    using (UserContext db = new UserContext())
                    {
                        FormsAuthentication.SetAuthCookie(model.Login, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и/или паролем не существует");
                }
            }
            return View(model);
        }

        // GET: Register Account.
        [Authorize(Roles = "Программист, Администратор")]
        public ActionResult Register()
        {
            UserContext context = new UserContext();
            ViewBag.Name = new SelectList(context.Roles.ToList(), "ID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            //ModelState.AddModelError("Login", "Неправильно набран логин");
            //ModelState.AddModelError("Password", "Неправильно набран пароль");
            if (ModelState.IsValid)
            {
                User user = null;
                using (UserContext db = new UserContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Login == model.Login);
                }
                if (user == null)
                {
                    // Создаем нового пользователя.
                    using (UserContext db = new UserContext())
                    {
                        if (model.Login == null || model.Password == null || model.Login == "" || model.Password == "")
                        {
                            ModelState.AddModelError("", "Неправельно заполнены поля логина и пароля");
                        }
                        else
                        {
                            db.Users.Add(new User { Login = model.Login, Password = model.Password, Role_ID = model.Role_ID });
                            db.SaveChanges();
                        }
                        

                        user = db.Users.Where(u => u.Login == model.Login && u.Password == model.Password).FirstOrDefault();
                    }
                    // Если успещно добавлен.
                    if (user != null)
                    {
                        ModelState.AddModelError("", "Пользователь зарегистрирован");
                        //return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }
            return View(model);
        }

        // GET: Logout Account.
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
        
    }
}