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
            Users sessionUser = Session["User"] as Users;
            Users user = userBLL.GetUser(sessionUser.ID);
            return View(user);
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

        [HttpGet]
        public ActionResult UpdateUser()
        {
            Users sessionUser = Session["User"] as Users;
            //Users user = userBLL.GetUser(sessionUser.ID);
            return View(sessionUser);
        }

        [HttpPost]
        public ActionResult UpdateUser(Users updatedUser)
        {//TODO passwordü iki kere girsin, eşleşirse update yapsın
            Users userInDB = userBLL.GetUser(updatedUser.ID);
            userInDB.Name = updatedUser.Name;
            userInDB.Email = updatedUser.Email;
            userInDB.Password = updatedUser.Password;
            userBLL.UpdateUser();
            Session["User"] = userBLL.GetUser(updatedUser.ID);
            return RedirectToAction("Index", "User");
        }

        //TODO kullanıcı kaydı başarılı diye pop up çıkacak
        //TODO aynı email ile kayıt yapmayacak
    }
}