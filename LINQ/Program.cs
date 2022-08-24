using System;
using System.Collections.Generic;
using System.Linq;
using LINQ.Entities;

namespace LINQ
{
    public class Program
    {
        private static void Print<T>(string message, IEnumerable<T> collection)
        {
            Console.WriteLine(message);

            foreach (T item in collection)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Category category1 = new Category { Id = 1, Name = "Tools", Tier = 2 };
            Category category2 = new Category { Id = 2, Name = "Computers", Tier = 1 };
            Category category3 = new Category { Id = 3, Name = "Eletronics", Tier = 1 };

            List<Product> products = new List<Product>
            {
                new Product { Id = 1, Name = "Hammer", Price = 90.0, Category = category1 },
                new Product { Id = 2, Name = "Computer", Price = 4600.0, Category = category2 },
                new Product { Id = 3, Name = "Xiamo MI A3", Price = 1000.0, Category = category3 },
                new Product { Id = 4, Name = "Fone Razer", Price = 269.0, Category = category2 },
                new Product { Id = 5, Name = "Axe", Price = 45.0, Category = category1 },
                new Product { Id = 6, Name = "Smartwatch Xiaomi", Price = 269.0, Category = category3 },
                new Product { Id = 7, Name = "TV", Price = 1500.0, Category = category3 },
                new Product { Id = 8, Name = "Saw", Price = 50.0, Category = category1 },
                new Product { Id = 9, Name = "Notebook", Price = 1400.0, Category= category2 },
                new Product { Id = 10, Name = "Camera", Price = 1000.0, Category = category3 },
                new Product { Id = 11, Name = "Sound Bar", Price = 860.0, Category = category3 }
            };

            var result1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900.0);
            Print("TIER 1 AND PRICE < 900: ", result1);

            var result2 = products.Where(p => p.Category.Name == "Tools").Select(p => p.Name);
            Print("NAME OF PRODUCTS FROM TOOLS", result2);

            var result3 = products.Where(p => p.Category.Name == "Eletronics").Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name });
            Print("ELETRONICS PRODUCTS", result3);

            var result4 = products.Where(p => p.Category.Tier == 1).OrderBy(p => p.Price).ThenBy(p => p.Name);
            Print("TIER 1 ORDER BY PRICE THEN BY NAME", result4);

            var result5 = products.FirstOrDefault();
            Console.WriteLine($"First or default test1: {result5}");

            var result6 = products.Where(p => p.Price > 5000.0).FirstOrDefault();
            Console.WriteLine($"First or default test2: {result6}");
            Console.WriteLine();

            var result7 = products.Where(p => p.Id == 3).SingleOrDefault();
            Console.WriteLine($"Single or default test1: {result7}");

            var result8 = products.Where(p => p.Id == 15).SingleOrDefault();
            Console.WriteLine($"Single or default test2: {result8}");


            Console.ReadKey();
        }
    }
}
