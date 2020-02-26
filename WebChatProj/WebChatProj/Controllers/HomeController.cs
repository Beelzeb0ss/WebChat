using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebChatProj.ViewModels.Home;
using WebChatProj.Repositories;
using WebChatProj.Entities;
using System.Web.Caching;
using WebChatProj.Utility;

namespace WebChatProj.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            IndexVM indexModel = new IndexVM();
            if(Session["loggedUser"] != null)
            {
                User current = (User)Session["loggedUser"];
                indexModel = ControllerStuff.GetIndexVM(current);
            }
            IndexBagVM model = new IndexBagVM() { AddFriendVM = new AddFriendVM(), IndexVM = indexModel};
            return View(model);
        }

        [HttpGet]
        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                UserRepo repo = new UserRepo();
                User loggedUser = repo.GetFirstOrDefault(u =>
                                            u.Username == model.Username &&
                                            u.Password == model.Password);

                if (loggedUser == null)
                    ModelState.AddModelError("AuthError", "Invalid username and password!");
                else
                    Session["loggedUser"] = loggedUser;
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session["loggedUser"] = null;

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                UserRepo repo = new UserRepo();
                User user = repo.GetFirstOrDefault(u => u.Username == model.Username);

                if (user == null)
                    repo.Insert(new User() { Username = model.Username, Password = model.Password, avatarID=1 });
                else
                    ModelState.AddModelError("UniqueUsernameError", "Username Taken");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult RemoveFriend(int id)
        {
            FriendRepo friendRepo = new FriendRepo();
            friendRepo.Delete(((User)Session["loggedUser"]).Id, id);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult AddFriend(IndexBagVM model)
        {
            if (ModelState.IsValid)
            {
                UserRepo userRepo = new UserRepo();
                User friend = userRepo.GetFirstOrDefault(i => i.Username == model.AddFriendVM.Username);
                if(friend == null)
                {
                    ModelState.AddModelError("NotFound", "User not found");
                }
                else
                {
                    FriendRepo friendRepo = new FriendRepo();
                    friendRepo.Insert(new Friend() { User1Id = ((User)Session["loggedUser"]).Id, User2Id = friend.Id });
                }
            }

            if(!ModelState.IsValid)
            {
                model.IndexVM = ControllerStuff.GetIndexVM((User)Session["loggedUser"]);
                return View("Index", model);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}