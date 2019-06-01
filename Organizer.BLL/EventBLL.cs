using Organizer.DAL;
using Organizer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.BLL
{
    public class EventBLL
    {
        DataContext db = new DataContext();

        public List<Events> ListEvents()
        {
            List<Events> eventList = db.Events.ToList();
            return eventList;
        }

        public void InsertEvent(Events filledEvent)
        {
            db.Events.Add(filledEvent);
            db.SaveChanges();
        }

        public List<Events> GetMyEvents(int ownerID)
        {
            List<Events> myEvents = db.Events.Where(x => x.OwnerID == ownerID).ToList();
            return myEvents;
        }

        public Events GetEvent(int eventID)
        {
            Events theEvent = db.Events.Where(x => x.ID == eventID).FirstOrDefault();
            return theEvent;
        }

        public void UpdateEvent()
        {
            db.SaveChanges();
        }

        public void DeleteEvent(int eventID)
        {
            Events theEvent = db.Events.Where(x => x.ID == eventID).FirstOrDefault();
            db.Events.Remove(theEvent);
            db.SaveChanges();
        }

        public void InsertUserEvent(UserEvent userEvent)
        {
            db.UserEvent.Add(userEvent);
            db.SaveChanges();
        }

        public void DeleteUserEvent(UserEvent userEvent)
        {
            db.UserEvent.Remove(userEvent);
            db.SaveChanges();
        }

        public List<UserEvent> GetIJoined(int userID)
        {
            List<UserEvent> userEvent = db.UserEvent.Where(x => x.UserID == userID).ToList();
            return userEvent;
        }

        public UserEvent GetUserEvent(int eventID)
        {
            UserEvent userEvent = db.UserEvent.Where(x => x.EventID == eventID).FirstOrDefault();
            return userEvent;
        }
    }
}
