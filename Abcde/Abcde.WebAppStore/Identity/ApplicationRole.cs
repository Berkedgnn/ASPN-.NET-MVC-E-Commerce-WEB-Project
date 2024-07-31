using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Abcde.WebAppStore.Identity
{
    //rolesini kullanmak için IdentityRole classından miras alıyoruz
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }
        //constructor oluşturuyoruz
        public ApplicationRole()
        {
            
        }
        // dışardan string ve rol adını alcak aşırı yüklenmiş versiyonunu oluşturduk.
        public ApplicationRole(string rolename,string description)
        {
            this.Description = description;
        }
    }
}