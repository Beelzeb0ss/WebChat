using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebChatProj.Entities;
using WebChatProj.Repositories;
using WebChatProj.Utility;
using WebChatProj.ViewModels.Group;

namespace WebChatProj.Controllers
{
    public class GroupController : Controller
    {

        public ActionResult Index()
        {
            ViewData["groups"] = ControllerStuff.GetGroupsFromUser(((User)Session["loggedUser"]), new GroupMemberRepo(), new GroupRepo());
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateVM model) {
            if (Session["loggedUser"] == null) RedirectToAction("Login", "Home");
            if (ModelState.IsValid)
            {
                GroupRepo repo = new GroupRepo();
                if (ControllerStuff.IsGroupNameUnique(model.Name, repo))
                {
                    repo.Insert(new Group() { Name = model.Name, OwnerID = ((User)Session["loggedUser"]).Id });
                    GroupMemberRepo gmr = new GroupMemberRepo();
                    gmr.Insert(new GroupMember() { GroupID = repo.GetFirstOrDefault(i => i.Name == model.Name).Id, MemberID = ((User)Session["loggedUser"]).Id });
                }
                else
                {
                    ModelState.AddModelError("UniqueNameError", "Name Taken");
                }
            }

            if(!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("Index", "Group");
        }

        public ActionResult Manage(int id)
        {
            GroupRepo groupRepo = new GroupRepo();
            if (((User)Session["loggedUser"]).Id == groupRepo.GetByID(id).OwnerID)
            {
                ViewData["groupMembers"] = ControllerStuff.GetGroupMembersAsUsers(id, new GroupMemberRepo(), new UserRepo()); 
                ViewData["group"] = groupRepo.GetByID(id);
                ViewData["friends"] = ControllerStuff.GetFriendsAsUsers(((User)Session["loggedUser"]), new FriendRepo(), new UserRepo());
                return View();
            }
            return RedirectToAction("Index", "Group");
        }

        public ActionResult AddMember(int memberId, int groupId)
        {
            GroupMemberRepo gmr = new GroupMemberRepo();
            gmr.Insert(new GroupMember() { GroupID = groupId, MemberID = memberId});
            return RedirectToAction("Manage", new RouteValueDictionary(new {action = "Manage", id = groupId }));
        }


        public ActionResult RemoveMember(int memberId, int groupId)
        {
            GroupMemberRepo gmr = new GroupMemberRepo();
            gmr.DeleteByMemberAndGroup(memberId, groupId);
            return RedirectToAction("Manage", new RouteValueDictionary(new { action = "Manage", id = groupId }));
        }

        public ActionResult Delete(int id) {
            GroupMemberRepo gmr = new GroupMemberRepo();
            gmr.DeleteByGroup(id);
            GroupRepo groupRepo = new GroupRepo();
            groupRepo.Delete(id);   
            return RedirectToAction("Index", "Group");
        }
    }
}