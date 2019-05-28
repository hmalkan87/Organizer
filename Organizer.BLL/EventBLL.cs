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
    }
}
