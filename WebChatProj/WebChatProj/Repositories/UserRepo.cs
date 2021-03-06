﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebChatProj.Entities;

namespace WebChatProj.Repositories
{
    public class UserRepo
    {
        private WebChatDbContext context = null;

        public UserRepo()
        {
            context = new WebChatDbContext();
        }

        public List<User> GetAll()
        {
            return context.Users.ToList();
        }

        public void Insert(User item)
        {
            item.avatarID = 1;
            context.Users.Add(item);

            context.SaveChanges();
        }

        public void Update(User item)
        {
            DbEntityEntry entry = context.Entry(item);
            entry.State = EntityState.Modified;

            context.SaveChanges();
        }

        public User GetById(int id)
        {
            return context.Users
                            .Where(i => i.Id == id)
                            .FirstOrDefault();
        }

        public User GetFirstOrDefault(Expression<Func<User, bool>> filter)
        {
            return context.Users
                      .Where(filter)
                      .FirstOrDefault();
        }

        public void Delete(int id)
        {
            User item = GetById(id);

            if (item != null)
            {
                context.Users.Remove(item);
                context.SaveChanges();
            }
        }
    }
}