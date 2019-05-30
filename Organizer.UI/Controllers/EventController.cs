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

        public ActionResult JoinEvent(int id)
        {
            Users user = Session["User"] as Users;
            UserEvent userEvent = new UserEvent();
            userEvent.EventID = id;
            userEvent.UserID = user.ID;
            eventBLL.JoinEvent(userEvent);
            return RedirectToAction("Index");
        }

        public ActionResult IJoined()
        {
            Users user = Session["User"] as Users;
            List<UserEvent> userEvent = eventBLL.GetIJoined(user.ID);
            return View(userEvent);
        }
    }
}