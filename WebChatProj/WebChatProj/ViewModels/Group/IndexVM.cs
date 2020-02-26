using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using entity = WebChatProj.Entities;

namespace WebChatProj.ViewModels.Group
{
    public class IndexVM
    {
        public List<entity.Group> Groups { get; set; }
    }
}