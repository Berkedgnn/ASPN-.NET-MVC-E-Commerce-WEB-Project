using Abcde.WebAppStore.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Abcde.WebAppStore.Identity
{
    //identity işlemleri için ayrı bir context oluşturuyoruz.
    public class IdentityDataContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityDataContext() : base("dataConnection")
        {
      
        }
    }
}