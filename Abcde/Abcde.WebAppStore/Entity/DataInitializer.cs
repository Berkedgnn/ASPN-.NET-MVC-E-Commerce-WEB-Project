using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Abcde.WebAppStore.Entity
{
    public class DataInitializer : DropCreateDatabaseAlways<DataContext>/*DropCreateDatabaseIfModelChanges<DataContext>*/
    {
        protected override void Seed(DataContext context)
        {
            //seed methodunu açığ test verilerini ekliyoruz
            var kategoriler = new List<Category>()
            {
                new Category(){Name="Kamera", Description="Kamera ürünleri"},
                 new Category(){Name="Telefon", Description="Telefon ürünleri"},
                  new Category(){Name="Tablet", Description="Tablet ürünleri"},
                   new Category(){Name="Bilgisayar", Description="Bilgisayar ürünleri"},
                    new Category(){Name="Oyun Konsolu", Description="Oyun Konsolu ürünleri"},
            };

            foreach (var category in kategoriler)
            {
                context.Categories.Add(category);
                //bu döngü ile yukarda eklediğimiz şeyler context aracılığıyla dbye eklenmiş olacak.
            }
            context.SaveChanges();
            // aynı işlemi test ürünleri için tekrarlıyoruz.

            var urunler = new List<Product>()
            {
             new Product(){Name="Sony Z1-compact", Description="model yılı 2024. 20megapixel autofocus compact camera", Price=500, Stock=100, IsApproved=true, CategoryId=1, IsHome=false, Image="1.jpg"},
             new Product(){Name="Sony ZvX2-PRO", Description="model yılı 2024. 25.1megapixel autofocus 5x optic zoom range profesional camera", Price=1100, Stock=50, IsApproved=true, CategoryId=1, IsHome=true, Image="2.jpg"},

             new Product(){Name="Iphone 12", Description="model yılı 2020. işlemci a14 bionic ram 6gb", Price=500, Stock=200, IsApproved=true, CategoryId=2, IsHome=true, Image="3.jpg"},
             new Product(){Name="Iphone 13", Description="model yılı 2021. işlemci a14 bionic ram 6gb", Price=600, Stock=200, IsApproved=true, CategoryId=2, IsHome=false, Image="4.jpg"},
             new Product(){Name="Iphone 14", Description="model yılı 2022. işlemci a14 bionic ram 6gb", Price=700, Stock=200, IsApproved=true, CategoryId=2, IsHome=true, Image="5.jpg"},
             new Product(){Name="Iphone 15", Description="model yılı 2023. işlemci a14 bionic ram 6gb", Price=800, Stock=200, IsApproved=true, CategoryId=2, IsHome=true, Image="6.jpg"},
             new Product(){Name="Iphone 16", Description="model yılı 2024. işlemci a14 bionic ram 6gb", Price=900, Stock=200, IsApproved=true, CategoryId=2, IsHome=true, Image="7.jpg"},

             new Product(){Name="Ipad air m1", Description="model yılı 2020. işlemci M1 ram 8gb", Price=1100, Stock=25, IsApproved=true, CategoryId=3, IsHome=true, Image="8.jpg"},
             new Product(){Name="Ipad air m2", Description="model yılı 2021. işlemci M2 8gb", Price=1200, Stock=25, IsApproved=true, CategoryId=3, IsHome=true, Image="9.jpg"},
             new Product(){Name="Ipad air m3", Description="model yılı 2022. işlemci M3 ram 8gb", Price=1300, Stock=25, IsApproved=true, CategoryId=3, IsHome=true, Image="10.jpg"},
             new Product(){Name="Ipad pro m2", Description="model yılı 2023. işlemci M2pro ram 16gb", Price=1800, Stock=25, IsApproved=true, CategoryId=3, IsHome=true, Image="11.jpg"},
             new Product(){Name="Ipad pro m4", Description="model yılı 2024. işlemci M3max ram 16gb", Price=2200, Stock=25, IsApproved=true, CategoryId=3, IsHome=true, Image="12.jpg"},

             new Product(){Name="Macbook air m1", Description="model yılı 2020. işlemci M1 ram 8gb", Price=1100, Stock=25, IsApproved=true, CategoryId=4, IsHome=false, Image="13.jpg"},
             new Product(){Name="Macbook air m2", Description="model yılı 2021. işlemci M2 8gb", Price=1200, Stock=25, IsApproved=true, CategoryId=4, IsHome=true, Image="14.jpg"},
             new Product(){Name="Macbook air m3", Description="model yılı 2022. işlemci M3 ram 8gb", Price=1300, Stock=25, IsApproved=true, CategoryId=4, IsHome=true, Image="15.jpg"},
             new Product(){Name="Macbook pro m2", Description="model yılı 2023. işlemci M2pro ram 16gb", Price=1800, Stock=25, IsApproved=true, CategoryId=4, IsHome=true, Image="16.jpg"},
             new Product(){Name="Macbook pro m3", Description="berkeeeee model yılı 2024. işlemci M3max ram 16gbvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv", Price=2200, Stock=25, IsApproved=true, CategoryId=4, IsHome=true, Image="17.jpg"},

             new Product(){Name="Xbox Series X", Description="model yılı 2020. Microsoft oyun konsolu 1TB", Price=500, Stock=250, IsApproved=false, CategoryId=5, IsHome=false, Image="18.jpg"},
             new Product(){Name="Playstation 5 Slim", Description="model yılı 2020. Sony oyun konsolu 1TB", Price=500, Stock=250, IsApproved=true, CategoryId=5, IsHome=true, Image="19.jpg"},
            };

            foreach (var urun in urunler)
            {
                context.Products.Add(urun);
                //bu döngü ile yukarda eklediğimiz şeyler context aracılığıyla dbye eklenmiş olacak.
            }
            context.SaveChanges();
            //bu data initializeri context içinde aktif etmemiz lazım
            base.Seed(context);
        }
    }
}