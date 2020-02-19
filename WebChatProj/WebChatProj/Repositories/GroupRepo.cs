using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebChatProj.Entities;

namespace WebChatProj.Repositories
{
    public class GroupRepo
    {
        private WebChatDbContext context = null;

        public GroupRepo()
        {
            context = new WebChatDbContext();
        }

        public List<Group> GetAll()
        {
            return context.Groups.ToList();
        }

        public void Insert(Group item)
        {
            context.Groups.Add(item);

            context.SaveChanges();
        }

        public void Update(Group item)
        {
            DbEntityEntry entry = context.Entry(item);
            entry.State = EntityState.Modified;

            context.SaveChanges();
        }

        public Group GetByID(int id)
        {
            return context.Groups
                            .Where(i => i.Id == id).FirstOrDefault();
        }

        public List<Group> GetListByFilter(Expression<Func<Group, bool>> filter)
        {
            IQueryable<Group> query = context.Groups;

            if (filter != null)
                query = query.Where(filter);

            return query.ToList();
        }

        public Group GetFirstOrDefault(Expression<Func<Group, bool>> filter)
        {
            return context.Groups
                      .Where(filter).FirstOrDefault();
        }

        public void Delete(int id)
        {
            Group item = GetByID(id);

            if (item != null)
            {
                context.Groups.Remove(item);
                context.SaveChanges();
            }
        }
    }
}