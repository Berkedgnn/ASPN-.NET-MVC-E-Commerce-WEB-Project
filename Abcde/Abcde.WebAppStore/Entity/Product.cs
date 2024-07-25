using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Abcde.WebAppStore.Entity
{
    public class Product
    {
        //main key oluşturmuş oluyoruz
        public int Id { get; set; }

        //Product bilgileri
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }

        //bu propu category tipinde oluşturduğumuz category ile gelen ıdyi table da tutmak için oluşturuyoruz.
        //bu şekilde her bir ürünün kategori ıdsi olmasını sağlıyoruz.
        //eğer her ürünün kategory idsi olmasını istemezsek nullable tipinde int? yaparak oluşturabiliriz.
        public int CategoryId { get; set; }

        //Bu prop ile ürünün onaylanıp onaylanmadığını denetleyip ona göre kullanıcıya listeleyeceğiz.
        public bool IsApproved { get; set; }

        //Bu prop ile ürünün ana sayfada listelenme durumunu denetleyeceğiz.

        public bool IsHome { get; set; }

        //her ürünün bir kategorisi olması için ve bunu atamak için kategori tipinden bir prop atayıp kategorilere erişmiş oluyoruz.
        public Category Category { get; set; }
        public string DetailedDescription { get; set; }
    }
}