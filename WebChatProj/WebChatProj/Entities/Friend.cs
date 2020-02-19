using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebChatProj.Entities
{
    public class Friend
    {
        [Key]
        public int ID { get; set; }
        public int User1Id { get; set; }
        public int User2Id { get; set; }

        [ForeignKey("User1Id")]
        public User User1 { get; set; }
        [ForeignKey("User2Id")]
        public User User2 { get; set; }
    }
}