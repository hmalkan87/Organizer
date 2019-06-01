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
        public ActionResult SendMessage(Messages message)
        {
            Users user = Session["User"] as Users;
            message.SenderID = user.ID;
            messageBLL.InsertMessage(message);
            return RedirectToAction("Index", "Event");
        }

        [HttpGet]
        public ActionResult ReplyMessage(int senderID)
        {
            Messages message = new Messages();
            message.ReceiverID = senderID;
            return View(message);
        }

        public ActionResult DeleteMessage(int id)
        {//TODO veritabanına IsDeleted kolonu ekleyip silinen mesajın IsDeleted değerini true ya da 1 yaparak hallet
            messageBLL.DeleteMessage(id);
            return RedirectToAction("MyMessages");
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