using Organizer.BLL;
using Organizer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Organizer.UI.Controllers
{
    public class EventController : Controller
    {
        EventBLL eventBLL = new EventBLL();
        public ActionResult Index()
        {
            TempData["LeaveFrom"] = "Index";
            List<Events> eventList = eventBLL.ListEvents();
            return View(eventList);
        }

        [HttpGet]
        public ActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEvent(Events filledEvent)
        {//TODO event oluşturunca otomatik olarak katılmış olsun.
            Users user = Session["User"] as Users;
            filledEvent.OwnerID = user.ID;
            filledEvent.NumberOfJoined = 0;
            eventBLL.InsertEvent(filledEvent);
            return RedirectToAction("MyEvents");
        }

        public ActionResult MyEvents()
        {
            Users user = Session["User"] as Users;
            List<Events> myEvents = eventBLL.GetMyEvents(user.ID);
            return View(myEvents);
        }

        [HttpGet]
        public ActionResult UpdateEvent(int id)
        {
            Events theEvent = eventBLL.GetEvent(id);
            return View(theEvent);
        }

        [HttpPost]
        public ActionResult UpdateEvent(Events updatedEvent)
        {
            Events eventInDB = eventBLL.GetEvent(updatedEvent.ID);
            eventInDB.Name = updatedEvent.Name;
            eventInDB.Picture = updatedEvent.Picture;
            eventInDB.EventDate = updatedEvent.EventDate;
            eventInDB.ApplicationDate = updatedEvent.ApplicationDate;
            eventInDB.Capacity = updatedEvent.Capacity;
            eventInDB.Description = updatedEvent.Description;
            eventBLL.UpdateEvent();
            return RedirectToAction("MyEvents");
        }

        public ActionResult DeleteEvent(int id)
        {//TODO IsDeleted kolonu ekleyip yap. bu haliyle zaten katılanlar ayrılmadan etkinliği silemiyor
            eventBLL.DeleteEvent(id);
            return RedirectToAction("MyEvents");
        }

        public ActionResult JoinEvent(int id, int capacity, int numberOfJoined)
        {
            if (numberOfJoined < capacity) //TODO bu şartı kaldırabilirsin. iki tane parametreye de gerek kalmaz. zaten katıl linki görünmüyor şart sağlanmadıkça.
            {
                Events theEvent = eventBLL.GetEvent(id);
                theEvent.NumberOfJoined++;
                Users user = Session["User"] as Users;
                UserEvent userEvent = new UserEvent();
                userEvent.EventID = id;
                userEvent.UserID = user.ID;
                eventBLL.InsertUserEvent(userEvent);
            }
            return RedirectToAction("Index");
        }

        public ActionResult LeaveEvent(int id)
        {//TODO buraya numberOfJoined > 0 şartı konulabilir. ama zaten viewde Ayrıl linki görünmez oluyo, bu şarta gerek kalmıyo.
            Events theEvent = eventBLL.GetEvent(id);
            theEvent.NumberOfJoined--;
            UserEvent userEvent = eventBLL.GetUserEvent(id);
            eventBLL.DeleteUserEvent(userEvent);
            string leaveFrom = TempData["LeaveFrom"] as string;
            if (leaveFrom == "IJoined")
            {
                return RedirectToAction("IJoined");
            }

            return RedirectToAction("Index");
        }

        public ActionResult IJoined()
        {
            TempData["LeaveFrom"] = "IJoined";
            Users user = Session["User"] as Users;
            List<UserEvent> userEvent = eventBLL.GetIJoined(user.ID);
            return View(userEvent);
        }

        public ActionResult EventDetails(int id)
        {
            List<UserEvent> userEventList = eventBLL.ListUserEvents(id);
            return View(userEventList);
        }

        //public ActionResult MessageAll()
        //{

        //}

        //TODO etkinlik silindiğinde katılmış olan herkese mesaj gidecek
    }
}