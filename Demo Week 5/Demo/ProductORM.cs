using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Week_5
{



    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;database=demo_week5;user=root;password=maheer2709;");
            }
        }

    }
    public class ProductORM
    {


        // Create
        public void AddProduct(Product product)
        {
            using var context = new ProductContext();
            context.Products.Add(product);
            context.SaveChanges();
        }

        // Read all
        public List<Product> GetAllProducts()
        {
            using var context = new ProductContext();
            return context.Products.ToList();
        }

        // Update
        public void UpdateProductPrice(int id, decimal newPrice)
        {
            using var context = new ProductContext();
            var product = context.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.Price = newPrice;
                context.SaveChanges();
            }
        }

        // Delete
        public void DeleteProduct(int id)
        {
            using var context = new ProductContext();
            var product = context.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }





    }
}
