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
        {
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
            eventInDB.Capacity = updatedEvent.Capacity;
            eventInDB.Description = updatedEvent.Description;
            eventBLL.UpdateEvent();
            return RedirectToAction("MyEvents");
        }

        public ActionResult DeleteEvent(int id)
        {
            eventBLL.DeleteEvent(id);
            return RedirectToAction("MyEvents");
        }

        public ActionResult JoinEvent(int id, int capacity, int numberOfJoined)
        {
            //List<UserEvent> uel = new List<UserEvent>();
            //int counter = 0;

            //foreach (var ue in uel)
            //{
            //    if (ue.EventID == id)
            //    {
            //        counter++;
            //    }
            //}

            if (!(numberOfJoined >= capacity))
            {
                Events theEvent = eventBLL.GetEvent(id);
                theEvent.NumberOfJoined++;
                Users user = Session["User"] as Users;
                UserEvent userEvent = new UserEvent();
                userEvent.EventID = id;
                userEvent.UserID = user.ID;
                eventBLL.JoinEvent(userEvent);
            }
            //else
            //{
            //    TempData["Capacity"] = "Kontenjan Dolu!";
            //}



            return RedirectToAction("Index");
        }

        public ActionResult IJoined()
        {
            Users user = Session["User"] as Users;
            List<UserEvent> userEvent = eventBLL.GetIJoined(user.ID);
            return View(userEvent);
        }

        //TODO etkinlik silindiğinde katılmış olan herkese mesaj gidecek
    }
}