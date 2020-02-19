using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebChatProj.ViewModels.Home
{
    public class RegisterVM
    {
        [DisplayName("Username: ")]
        [Required(ErrorMessage = "This field is required and should be unique!")]
        public string Username { get; set; }

        [DisplayName("Password: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Password { get; set; }
    }
}