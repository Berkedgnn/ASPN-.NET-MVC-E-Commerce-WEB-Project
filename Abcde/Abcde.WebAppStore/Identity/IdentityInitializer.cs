using Abcde.WebAppStore.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace Abcde.WebAppStore.Identity
{
    public class IdentityInitializer : CreateDatabaseIfNotExists<IdentityDataContext>
    {

        protected override void Seed(IdentityDataContext context)
        {
            //roles
            if (!context.Roles.Any(i => i.Name == "admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "admin", Description = "admin role" };
                manager.Create(role);
            }

            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "user", Description = "user role" };
                manager.Create(role);
            }

            //Users

            if (!context.Users.Any(i => i.Name == "ElectronzzSTR"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser()
                {
                    Name = "Sadık",
                    Surname = "Kınalı",
                    UserName = "ElectronzzSTR",
                    Email = "electronz@eposta.com.tr",
                };
                manager.Create(user, "123456789");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
            }

            if (!context.Users.Any(i => i.Name == "berkedgn"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser()
                {
                    Name = "Berke",
                    Surname = "Dogan",
                    UserName = "Berke_D",
                    Email = "deneme@eposta.com.tr",
                };
                manager.Create(user, "123456789");
                manager.AddToRole(user.Id, "user");
            }

           

            base.Seed(context);
        }

    }
}