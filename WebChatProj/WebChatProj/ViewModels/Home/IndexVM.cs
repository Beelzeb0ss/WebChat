using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using entity = WebChatProj.Entities;

namespace WebChatProj.ViewModels.Home
{
    public class IndexVM
    {
        public List<entity.Group> Groups { get; set; }
        public List<entity.User> Friends { get; set; }
        public List<entity.Avatar> Avatars { get; set; }

    }
}