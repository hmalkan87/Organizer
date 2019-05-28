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
            Events EmptyEvent = new Events();
            return View(EmptyEvent);
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
    }
}