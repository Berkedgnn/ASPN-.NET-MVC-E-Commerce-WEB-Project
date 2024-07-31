using Abcde.WebAppStore.Identity;
using Abcde.WebAppStore.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Abcde.WebAppStore.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;

        public AccountController()
        {
            //kullanıcıyı ve rolünü depolayacak değişkenlerin oluşturulması.
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                //kayıt operasyonları yapılır
                ApplicationUser user = new ApplicationUser();
                user.Name = model.Name;
                user.Surname = model.SurName;
                user.Email = model.Email;
                user.UserName = model.UserName;
                //model üzerinden gelen verilerle applicationuser tipindeki kullanıcıyı dolduruyoruz.

                //usermanager yardımıyla kullanıcıyı kayıt etmiş oluyoruz.
                IdentityResult result = UserManager.Create(user, model.Password);

                if (result.Succeeded)
                {
                    //kayıt başarılı kullanıcıyı bir role atayabiliriz.
                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login", "Account");

                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Can not register to system");
                };

            }
            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                //giriş operasyonları yapılır
                var user = UserManager.Find(model.UserName, model.Password);
                if (user != null)
                {
                    //varolan kullanıcıyı applicationcookie ile sisteme bırakıcaz
                    var authManager = HttpContext.GetOwinContext().Authentication;

                    //oluşan user cookie içerisine atılır
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");

                    //eklenen cookinin kalıcı mı geçici mi olduğunu belirleme
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;

                    authManager.SignIn(authProperties, identityclaims);

                    //eğer bir sayfaya ulaşmak isterken login olmamızı isterse ve bizi login ekranına atarsa login olduktan sonra home
                    //gitmek yerine returnurlye gitsin 
                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Can not Login to system");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            //öncelikle authentication managere ihtiyacımız var.(Oluşturduğumuz cookieyi sistemden silmiş oluyoruz.)
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}