using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebChatProj.ChatR;

namespace WebChatProj.Controllers
{
    public class ChatController : Controller
    {

        public ActionResult GroupChat(int groupID)
        {
            ViewData["groupID"] = groupID;
            return View();
        }
    }
}