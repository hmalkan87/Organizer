using Organizer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Organizer.UI.Models
{
    public class MessageModel
    {
        public string SenderName { get; set; }
        public string MessageText { get; set; }

        public List<Messages> messages { get; set; }

        public Messages message { get; set; }
    }
}