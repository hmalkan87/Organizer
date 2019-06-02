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
            Messages message = new Messages();//eğer burda da SendBulkMessage ekşınlarındaki gibi kurgulasaydık o çokomelli yere gerek kalmayacaktı.
            message.ReceiverID = ownerID;
            Users user = userBLL.GetUser(ownerID);
            message.Users = user;
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
        public ActionResult SendBulkMessage()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult SendBulkMessage(Messages message)
        {
            List<UserEvent> list = TempData["Bulk"] as List<UserEvent>;
            Users user = Session["User"] as Users;
            foreach (UserEvent item in list)
            {
                message.ReceiverID = item.UserID;
                message.SenderID = user.ID;
                messageBLL.InsertMessage(message);
            }
            return RedirectToAction("MyMessages");
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