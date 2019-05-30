using Organizer.DAL;
using Organizer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.BLL
{
    public class MessageBLL
    {
        DataContext db = new DataContext();

        public List<Messages> MyMessages(int messageID)
        {
            List<Messages> messageList = db.Messages.Where(x => x.ID == messageID).ToList();
            return messageList;
        }

        public Messages GetMessage(int messageID)
        {
            Messages message = db.Messages.Where(x => x.ID == messageID).FirstOrDefault();
            return message;
        }

        public Users getUser(int userId)
        {
            Users user = db.Users.Where(x => x.ID == userId).FirstOrDefault();
            return user;
        }
    }
}
