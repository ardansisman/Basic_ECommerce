using Proje.Common.Entities;
using Proje.Common.Entities.Domain;
using Proje.Common.SystemConstant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Proje.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            using (MyDb db = new MyDb())
            {
                if (db.Database.CreateIfNotExists())
                {


                    List<Product> products = new List<Product>();
                    Product product = new Product()
                    {
                        Description = "Ürün açıklamaları",
                        Image = "1.jpg",
                        Name = "Product1",
                        Brand = "Brand1",
                        Price = 1111,
                    };

                    Product product2 = new Product()
                    {
                        Description = "Ürün açıklamaları",
                        Image = "2.png",
                        Name = "Product2",
                        Brand = "Brand2",
                        Price = 1112,
                    };
                    Product product3 = new Product()
                    {
                        Description = "Ürün açıklamaları",
                        Image = "3.jpg",
                        Name = "Product3",
                        Brand = "Brand3",
                        Price = 1113,
                    };
                    Product product4 = new Product()
                    {
                        Description = "Ürün açıklamaları",
                        Image = "4.png",
                        Name = "Product4",
                        Brand = "Brand4",
                        Price = 1114,
                    };
                    Product product5 = new Product()
                    {
                        Description = "Ürün açıklamaları",
                        Image = "5.jpg",
                        Name = "Product5",
                        Brand = "Brand5",
                        Price = 1115,
                    };
                    Product product6 = new Product()
                    {
                        Description = "Ürün açıklamaları",
                        Image = "6.jpg",
                        Name = "Product6",
                        Brand = "Brand6",
                        Price = 1116,
                    };
                    Product product7 = new Product()
                    {
                        Description = "Ürün açıklamaları",
                        Image = "7.jpg",
                        Name = "Product7",
                        Brand = "Brand7",
                        Price = 1117,

                    };
                    Product product8 = new Product()
                    {
                        Description = "Ürün açıklamaları",
                        Image = "8.jpg",
                        Name = "Product8",
                        Brand = "Brand8",
                        Price = 1118,
                    };
                    Product product9 = new Product()
                    {
                        Description = "Ürün açıklamaları",
                        Image = "9.jpg",
                        Name = "Product9",
                        Brand = "Brand9",
                        Price = 1119,
                    };
                    Product product10 = new Product()
                    {
                        Description = "Ürün açıklamaları",
                        Image = "10.jpg",
                        Name = "Product10",
                        Brand = "Brand10",
                        Price = 1120,
                    };
                    products.Add(product);
                    products.Add(product2);
                    products.Add(product3);
                    products.Add(product4);
                    products.Add(product5);
                    products.Add(product6);
                    products.Add(product7);
                    products.Add(product8);
                    products.Add(product9);
                    products.Add(product10);

                    List<Category> categories = new List<Category>();
                    Category category = new Category()
                    {
                        Name = "Category1"
                    };
                    Category category2 = new Category()
                    {
                        Name = "Category2"
                    };
                    categories.Add(category);
                    categories.Add(category2);

                    List<ImageGallery> galleries = new List<ImageGallery>();
                    ImageGallery ımage1 = new ImageGallery()
                    {
                        Product = product,
                        Path = "p1_1.jpg"
                    };
                    ImageGallery ımage1_1 = new ImageGallery()
                    {
                        Product = product,
                        Path = "p1_2.jpg"
                    };
                    ImageGallery ımage2 = new ImageGallery()
                    {
                        Product = product2,
                        Path = "p2_1.jpg"
                    };
                    ImageGallery ımage2_2 = new ImageGallery()
                    {
                        Product = product2,
                        Path = "p2_2.jpg"
                    };
                    ImageGallery ımage3 = new ImageGallery()
                    {
                        Product = product3,
                        Path = "p3_1.jpg"
                    };
                    ImageGallery ımage3_2 = new ImageGallery()
                    {
                        Product = product3,
                        Path = "p3_2.jpg"
                    };
                    ImageGallery ımage4 = new ImageGallery()
                    {
                        Product = product4,
                        Path = "p4_1.jpg"
                    };
                    ImageGallery ımage4_2 = new ImageGallery()
                    {
                        Product = product4,
                        Path = "p4_2.jpg"
                    };
                    ImageGallery ımage5 = new ImageGallery()
                    {
                        Product = product5,
                        Path = "p5_1.jpg"
                    };
                    ImageGallery ımage5_2 = new ImageGallery()
                    {
                        Product = product5,
                        Path = "p5_2.jpg"
                    };
                    ImageGallery ımage6 = new ImageGallery()
                    {
                        Product = product6,
                        Path = "p6_1.jpg"
                    };
                    ImageGallery ımage6_2 = new ImageGallery()
                    {
                        Product = product6,
                        Path = "p6_2.jpg"
                    };
                    galleries.Add(ımage1);
                    galleries.Add(ımage1_1);
                    galleries.Add(ımage2_2);
                    galleries.Add(ımage2);
                    galleries.Add(ımage3_2);
                    galleries.Add(ımage3);
                    galleries.Add(ımage4_2);
                    galleries.Add(ımage5_2);
                    galleries.Add(ımage6_2);
                    galleries.Add(ımage4);
                    galleries.Add(ımage5);
                    galleries.Add(ımage6);
                    User user = new User()
                    {
                        Name = "mersus",
                        Email = "mersus@info.com",
                        isActive = true,
                        Password = Security.sha512encrypt("123456").Substring(0,40),

                    };
                    db.Users.Add(user);
                    db.Products.AddRange(products);
                    db.ImageGalleries.AddRange(galleries);
                    db.Categories.AddRange(categories);
                    db.SaveChanges();
                }
            }
        }
    }
}
