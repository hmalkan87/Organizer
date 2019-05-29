using Organizer.BLL;
using Organizer.Entity;
using Organizer.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Organizer.UI.Controllers
{
    public class LoginController : Controller
    {
        LoginBLL loginBLL = new LoginBLL();
        public ActionResult Index()
        {
            return View();

        }

        public ActionResult Login(LoginModel model)
        {
            if (model.UserName == null || model.Password == null)
            {
                TempData["Error"] = "Email ya da şifre girmediniz!";
                return RedirectToAction("Index");
            }

            Users user = loginBLL.LoginUser(model.UserName, model.Password);

            //TempData["UserName"] = model.UserName.ToString();

            if (user == null)
            {
                TempData["Error"] = "Email ve şifre eşleşmedi!";
                return RedirectToAction("Index");
            }
            else
            {
                Session["User"] = user;
                return RedirectToAction("Index", "Event");
            }
        }

        public ActionResult Logout()
        {
            if (Session["User"] != null)
            {
                Session["User"] = null;
            }
            return RedirectToAction("Index");
        }

        //TODO subscriberID, ownerID kolonları eklenecek UserEvent tablosuna
        //TODO silerken pop up çıkacak
        //TODO mesajlaşma yapılacak
    }
}