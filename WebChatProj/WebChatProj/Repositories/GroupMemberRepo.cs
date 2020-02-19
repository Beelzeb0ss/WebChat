using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Web;
using WebChatProj.Entities;

namespace WebChatProj.Repositories
{
    public class GroupMemberRepo
    {
        private WebChatDbContext context = null;

        public GroupMemberRepo()
        {
            context = new WebChatDbContext();
        }

        public List<GroupMember> GetAll()
        {
            return context.GroupMembers.ToList();
        }

        public void Insert(GroupMember item)
        {
            context.GroupMembers.Add(item);

            context.SaveChanges();
        }

        public void Update(GroupMember item)
        {
            DbEntityEntry entry = context.Entry(item);
            entry.State = EntityState.Modified;

            context.SaveChanges();
        }

        public List<GroupMember> GetByID(int id)
        {
            return context.GroupMembers
                            .Where(i => i.Id == id).ToList();
        }

        public List<GroupMember> GetListByFilter(Expression<Func<GroupMember, bool>> filter)
        {
            IQueryable<GroupMember> query = context.GroupMembers;

            if (filter != null)
                query = query.Where(filter);

            return query.ToList();
        }

        public GroupMember GetFirstOrDefault(Expression<Func<GroupMember, bool>> filter)
        {
            return context.GroupMembers
                      .Where(filter).FirstOrDefault();
        }

        public void DeleteByMemberAndGroup(int memberId, int groupId)
        {
            List<GroupMember> items = GetListByFilter(i => i.GroupID == groupId && i.MemberID == memberId);

            foreach (var item in items)
            {
                context.GroupMembers.Remove(item);
            }
            context.SaveChanges();
        }

        public void DeleteByGroup(int groupID)
        {
            List<GroupMember> items = GetListByFilter(i=>i.GroupID == groupID);

            foreach (var item in items)
            {
                context.GroupMembers.Remove(item);
            }
            context.SaveChanges();
        }
    }
}