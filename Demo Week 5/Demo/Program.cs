// See https://aka.ms/new-console-template for more information
using Demo_Week_5;
using System;

namespace DemoWeek5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(" LINQ Demo\n");
            //LINQList.RunLINQList();

            //Console.WriteLine("\nLINQ Demo on DataTable ");
            //LinqDataTableDemo.RunDataTableDemo();


            //var orm = new ProductORM();

            //// Add products
            //orm.AddProduct(new Product { Name = "Laptop", Price = 55000, Quantity = 5 });
            //orm.AddProduct(new Product { Name = "Mouse", Price = 500, Quantity = 50 });

            //// Display all products
            //Console.WriteLine("All Products:");
            //foreach (var p in orm.GetAllProducts())
            //{
            //    Console.WriteLine($"Id:{p.Id}, Name:{p.Name}, Price:{p.Price}, Qty:{p.Quantity}");
            //}

            //// Update price of first product
            //var products = orm.GetAllProducts();
            //if (products.Count > 0)
            //{
            //    orm.UpdateProductPrice(products[0].Id, 60000);
            //    Console.WriteLine("\nUpdated first product price!");
            //}

            //// Delete second product
            //if (products.Count > 1)
            //{
            //    orm.DeleteProduct(products[1].Id);
            //    Console.WriteLine("\nDeleted second product!");
            //}

            //// Final products
            //Console.WriteLine("\nFinal Products:");
            //foreach (var p in orm.GetAllProducts())
            //{
            //    Console.WriteLine($"Id:{p.Id}, Name:{p.Name}, Price:{p.Price}, Qty:{p.Quantity}");
            //}




            // Security
            //Security.EncryptDecryptAES();
            //Security.EncryptDecryptRSA();
            //Security.ComputeSHA256();
            //Security.DigitalSignAndVerify();



            dynamic a = 10;
            Console.WriteLine(a);

            a = "Hello";
            Console.WriteLine(a);
        }
    }
}
