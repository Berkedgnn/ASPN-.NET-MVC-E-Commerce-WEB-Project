using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(Abcde.WebAppStore.App_Start.Startup1))]

namespace Abcde.WebAppStore.App_Start
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {

            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            //Authentication tipini belirliyoruz (Temel Ayarlar)
            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions()
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Account/Login")
                //kullanıcı bi yerlere tıklatıp gitmek istediğinde varsayılan olarak nereye gideceğini belirliyoruz.
                //(Giriş yapmadan Başka yerlere gitmemesi için)
            });

        }
    }
}
