using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using entity = WebChatProj.Entities;

namespace WebChatProj.ViewModels.Group
{
    public class ManageVM
    {
        public List<entity.User> GroupMembers { get; set; }
        public entity.Group Group { get; set; }
        public List<entity.User> Friends { get; set; }
    }
}