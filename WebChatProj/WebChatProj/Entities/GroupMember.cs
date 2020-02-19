using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebChatProj.Entities
{
    public class GroupMember
    {
        [Key]
        public int Id { get; set; }
        public int GroupID { get; set; }
        public int MemberID { get; set; }//behse MemberID

        [ForeignKey("GroupID")]
        public Group Group { get; set; }
        [ForeignKey("MemberID")]
        public User User { get; set; }
    }
}