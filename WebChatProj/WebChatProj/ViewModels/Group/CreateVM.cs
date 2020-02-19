using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebChatProj.ViewModels.Group
{
    public class CreateVM
    {
        [DisplayName("Name: ")]
        [Required(ErrorMessage = "This field is required and should be unique!")]
        public string Name { get; set; }
    }
}