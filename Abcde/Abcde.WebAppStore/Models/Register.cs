using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Abcde.WebAppStore.Models
{
    public class Register
    {
        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Surname")]
        public string SurName { get; set; }

        [Required]
        [DisplayName("Public User Name")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("E-mail adress")]
        [EmailAddress(ErrorMessage = "Enter valid mail adress")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Password")]

        public string Password { get; set; }
        [Required]
        [DisplayName("Re password")]
        [Compare("Password", ErrorMessage = "Passwords must be matched")]
        public string RePassword { get; set; }
    }
}