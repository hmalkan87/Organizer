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
    public class MessageController : Controller
    {
        MessageBLL messageBLL = new MessageBLL();
        UserBLL userBLL = new UserBLL();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MyMessages()
        {
            Users user = Session["User"] as Users;
            List<Messages> messageList = messageBLL.GetMyMessages(user.ID);
            return View(messageList);
        }

        [HttpGet]
        public ActionResult SendMessage(int ownerID)
        {
            Messages message = new Messages();
            message.ReceiverID = ownerID;
            return View(message);
        }

        [HttpPost]
        public ActionResult SendMessage2(Messages message/*int ownerID*/)
        {
            Users user = Session["User"] as Users;
            //Messages message = new Messages();
            message.SenderID = user.ID;
            //message.ReceiverID = ownerID;
            messageBLL.InsertMessage(message);
            return RedirectToAction("Index", "Event");
        }

        //public ActionResult MyMessages()
        //{
            
        //    //Messages message = messageBLL.GetMessage() ;
        //    Users user1 = userBLL.GetUser(message.SenderID);

        //    TempData["SenderName"] = user1.Name;
        //    Users user = Session["User"] as Users;
        //    List<Messages> messageList = messageBLL.MyMessages(user.ID);
        //    return View(messageList);

        //  //TODO burayı Message modeli oluşturup içine Messages tablosundan MessageText, Users tablosundan Name kısımlarını alarak yapmaya çalış
        //}

        //public ActionResult MyMessages2()
        //{

        //    //Messages message = messageBLL.GetMessage() ;
        //    //Users user1 = userBLL.GetUser(message.SenderID);

        //    //TempData["SenderName"] = user1.Name;
        //    Users user = Session["User"] as Users;
        //    List<Messages> messageList = messageBLL.MyMessages(user.ID);
        //    return View(messageList);

        //   //TODO burayı Message modeli oluşturup içine Messages tablosundan MessageText, Users tablosundan Name kısımlarını alarak yapmaya çalış
        //}
        
    }
}