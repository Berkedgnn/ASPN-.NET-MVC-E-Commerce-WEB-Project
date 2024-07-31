using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Abcde.WebAppStore.Models
{
    public class Login
    {
        [Required]
        [DisplayName("Public User Name")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }

        //şifreyi kaydetmek için bir bool tipi değişken
        [DisplayName("Remember Me Later")]
        public bool RememberMe { get; set; }
    }
}