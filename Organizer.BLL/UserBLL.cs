using Organizer.DAL;
using Organizer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.BLL
{
    public class UserBLL
    {
        DataContext db = new DataContext();

        public Users GetUser(int userID)
        {
            Users user = db.Users.Where(x => x.ID == userID).FirstOrDefault();
            return user;
        }
    }
}
