using Organizer.BLL;
using Organizer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Organizer.UI.Controllers
{
    public class UserController : Controller
    {
        UserBLL userBLL = new UserBLL();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(Users user)
        {
            userBLL.InsertUser(user);
            return RedirectToAction("Index", "Login");
        }

        //TODO kullanıcı kaydı başarılı diye pop up çıkacak
        //TODO aynı email ile kayıt yapmayacak
    }
}