using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebChatProj.Entities;
using WebChatProj.Repositories;
using HomeVM = WebChatProj.ViewModels.Home;

namespace WebChatProj.Utility
{
    public static class ControllerStuff
    {

        public static HomeVM.IndexVM GetIndexVM(User user)
        {
            HomeVM.IndexVM indexModel = new HomeVM.IndexVM();
            indexModel.Groups = ControllerStuff.GetGroupsFromUser(user, new GroupMemberRepo(), new GroupRepo());
            indexModel.Friends = ControllerStuff.GetFriendsAsUsers(user, new FriendRepo(), new UserRepo());
            indexModel.Avatars = ControllerStuff.GetFriendsAvatars(indexModel.Friends, new AvatarRepo());
            return indexModel;
        }

        public static List<User> GetFriendsAsUsers(User current, FriendRepo friendRepo, UserRepo userRepo) {
            List<Friend> friends;
            friends = friendRepo.GetListByFilter(i => i.User1Id == current.Id);
            List<User> userFriends = new List<User>();
            foreach (var item in friends)
            {
                userFriends.Add(userRepo.GetById(item.User2Id));
            }
            return userFriends;
        }

        public static List<User> GetGroupMembersAsUsers(int groupID, GroupMemberRepo gmr, UserRepo userRepo)
        {
            List<GroupMember> members;
            members = gmr.GetListByFilter(i => i.GroupID == groupID);
            List<User> friends = new List<User>();
            foreach (var item in members)
            {
                friends.Add(userRepo.GetById(item.MemberID));
            }
            return friends;
        }

        public static bool IsGroupNameUnique(string name, GroupRepo repo)
        {
            Group group = repo.GetFirstOrDefault(i => i.Name == name);
            if (group != null)
                return false;
            else
                return true;
        }

        public static List<Avatar> GetFriendsAvatars(List<User> friends, AvatarRepo repo)
        {
            List<Avatar> avatars = new List<Avatar>();
            foreach (var item in friends)
            {
                avatars.Add(repo.GetFirstOrDefault(item.avatarID));
            }
            return avatars;
        }

        public static List<Group> GetGroupsFromUser(User current, GroupMemberRepo gmr, GroupRepo gr)
        {
            List<GroupMember> groupsAsM;
            List<Group> groups = new List<Group>();
            groupsAsM = gmr.GetListByFilter(i => i.MemberID == current.Id);
            foreach (var item in groupsAsM)
            {
                groups.Add(gr.GetByID(item.GroupID));
            }
            return groups;
        }

        public static bool IsUserInList(User item, List<User> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if(item.Id == list[i].Id)
                {
                    return true;
                }
            }
            return false;
        }

    }

}