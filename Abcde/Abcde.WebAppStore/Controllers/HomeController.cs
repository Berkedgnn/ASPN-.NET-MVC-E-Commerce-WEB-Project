using Abcde.WebAppStore.Entity;
using Abcde.WebAppStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Abcde.WebAppStore.Controllers
{
    public class HomeController : Controller
    {
        DataContext _context = new DataContext();
        // GET: Home
        public ActionResult Index()
        {
            //filtreleyerek ana sayfaya yolluyoruz.
            //her bir product için model oluşturup onu doldurur.
            var urunler = _context.Products.Where(i => i.IsHome && i.IsApproved).Select(i => new ProductModel()
            {
                Id = i.Id,
                Name = i.Name,
                Price = i.Price,
                Image = i.Image,
                CategoryId = i.CategoryId,
                Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                Stock = i.Stock
            }).ToList();
            return View(urunler);
        }

        public ActionResult Details(int id)
        {
            return View(_context.Products.Where(i => i.Id == id).SingleOrDefault());
        }
        public ActionResult List(int? id)
        {
            //tüm ürünleri göstereceğimiz için filtreye gerek yok.
            var urunler = _context.Products.Where(i => i.IsApproved).Select(i => new ProductModel()
            {
                Id = i.Id,
                Name = i.Name,
                Price = i.Price,
                Image = i.Image,
                CategoryId = i.CategoryId,
                Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                Stock = i.Stock
            }).AsQueryable();
            //bu yapıyla sorhuyu yazmış oluyoruz.

            if(id != null)
            {
                //eğer id null değilse yani sidebardan bir kategori seçildiyse bu
                //filtreleme üstteki sorguya eklenecek ve list.htmle öyle gidecek.
                urunler= urunler.Where(i => i.CategoryId == id);
            }

            return View(urunler.ToList());
        }

        public PartialViewResult GetCategories()
        {
            //tüm kategorileri partial viewe yollamış oluyoruz.
            return PartialView(_context.Categories.ToList());
        }
    }
}