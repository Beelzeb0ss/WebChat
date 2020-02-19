using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebChatProj.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Index(IsUnique = true)]
        public string Username { get; set; }
        public string Password { get; set; }
        public int avatarID { get; set; }

        [ForeignKey("avatarID")]
        public Avatar avatar;
    }
}