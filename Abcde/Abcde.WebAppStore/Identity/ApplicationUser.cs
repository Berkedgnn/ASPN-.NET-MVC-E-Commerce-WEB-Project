using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Abcde.WebAppStore.Identity
{
    //identityuser sınıfından miras alması gerekiyor.(default entityframework user implementation).
    //dışardan id ve username alıyor.
    public class ApplicationUser: IdentityUser
    {
        // IdentityUser'da zaten id ve username var diğer gerekli propları da biz ekliyoruz.
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}