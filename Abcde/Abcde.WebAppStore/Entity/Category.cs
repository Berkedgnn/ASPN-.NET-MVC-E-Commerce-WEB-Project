using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Abcde.WebAppStore.Entity
{
    public class Category
    {
        public int Id { get; set; }

        //kategorinin adı ve açıklaması örneğin => elektronik ev aletleri/ günlük kullanıma yönelik küçük cihazlar
        public string Name { get; set; }
        public string Description { get; set; }

        //bir kategorideyken o kategoriye ait ürünlere erişmek için (aslında kategoriye ürünleri atıyoruz)
        public List<Product> Products { get; set; }
        //bununla bir kategorideyken .products yaptığımızda ona bağlı olan ürünlere erişebileceğiz.

    }
}