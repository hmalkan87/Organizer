using Organizer.DAL;
using Organizer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.BLL
{
    public class LoginBLL
    {
        DataContext db = new DataContext();

        public Users LoginUser(string username, string password)
        {
            Users user = db.Users.Where(x => x.Email == username && x.Password == password).FirstOrDefault();
            return user;
        }
    }
}
