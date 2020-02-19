using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebChatProj.Entities
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        [Index(IsUnique = true)]
        public string Name{ get; set; }
        public int OwnerID { get; set; }

        [ForeignKey("OwnerID")]
        public User Owner { get; set; }
    }
}