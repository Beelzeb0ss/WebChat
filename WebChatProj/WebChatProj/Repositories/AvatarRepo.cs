using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebChatProj.Entities;

namespace WebChatProj.Repositories
{
    public class AvatarRepo
    {
        private WebChatDbContext context = null;

        public AvatarRepo()
        {
            context = new WebChatDbContext();
        }

        public Avatar GetFirstOrDefault(int id)
        {
            return context.Avatars
                      .Where(i => i.ID == id).FirstOrDefault();
        }

        public Avatar GetFirstOrDefault(Expression<Func<Avatar, bool>> filter)
        {
            return context.Avatars
                      .Where(filter)
                      .FirstOrDefault();
        }
    }
}