namespace Proje.Common.Entities
{
    using Proje.Common.Entities.Domain;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MyDb : DbContext,IDisposable
    {
        // Your context has been configured to use a 'MyDb' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Proje.Common.Entities.MyDb' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MyDb' 
        // connection string in the application configuration file.
        public MyDb()
            : base("name=MyDb")
        {
        }
        public virtual DbSet<Basket> Baskets { get; set; }
        public virtual DbSet<ImageGallery> ImageGalleries { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Token> Tokens { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}