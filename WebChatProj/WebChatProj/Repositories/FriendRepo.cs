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
    public class FriendRepo
    {
        private WebChatDbContext context = null;

        public FriendRepo()
        {
            context = new WebChatDbContext();
        }

        public List<Friend> GetAll()
        {
            return context.Friends.ToList();
        }

        public void Insert(Friend item)
        {
            context.Friends.Add(item);

            context.SaveChanges();
        }

        public void Update(Friend item)
        {
            DbEntityEntry entry = context.Entry(item);
            entry.State = EntityState.Modified;

            context.SaveChanges();
        }

        public List<Friend> GetByUser1Id(int user1id)
        {
            return context.Friends
                            .Where(i => i.User1Id == user1id).ToList();
        }

        public List<Friend> GetListByFilter(Expression<Func<Friend, bool>> filter)
        {
            IQueryable<Friend> query = context.Friends;

            if (filter != null)
                query = query.Where(filter);

            return query.ToList();
        }

        public Friend GetFirstOrDefault(int id1, int id2)
        {
            return context.Friends
                      .Where(i =>i.User1Id == id1 && i.User2Id == id2).FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id1">current user</param>
        /// <param name="id2">friend to remove</param>
        public void Delete(int id1, int id2)
        {
            Friend item = GetFirstOrDefault(id1, id2);

            if (item != null)
            {
                context.Friends.Remove(item);
                context.SaveChanges();
            }
        }
    }
}