using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebChatProj.Entities;

namespace WebChatProj.Repositories
{
    public class WebChatDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<Avatar> Avatars { get; set; }

        public WebChatDbContext() : base("MySqlConnection")
        {
            Users = this.Set<User>();
            Friends = this.Set<Friend>();
            Groups = this.Set<Group>();
            GroupMembers = this.Set<GroupMember>();
            Avatars = this.Set<Avatar>();
        }
    }
}