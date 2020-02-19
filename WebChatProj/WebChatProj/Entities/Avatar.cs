using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebChatProj.Entities
{
    public class Avatar
    {
        [Key]
        public int ID { get; set; }
        public string avatar { get; set; }
    }
}