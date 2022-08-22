using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace freelanceProject.Model
{
    public class EntityContext : IdentityDbContext<User>
    {
        public EntityContext() : base()
        {

        }
        public EntityContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-QCP50NS;Initial Catalog=E-Commerce_Final_Project;Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);
        }
        
        //Entities
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<HomeInfo> HomeInfo { get; set; }
        public DbSet<Partner> Partners { get; set; }

        public DbSet<User> Users { get; set; }


        public DbSet<ProductDetails> ProductDetails { get; set; }


    }
}
