using SalesTaxApp.Interface;
using SalesTaxApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesTaxApp.Implementation
{
    class ProductParser : IProductParser
    {
        public List<Product> GetProducts()
        {
            List <Product> productList = new List<Product>();
            Console.WriteLine("-------------Enter Product Details-----------------");
            Console.WriteLine("----------Type 'done' to print receipt ----------------");
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "done")
                {
                    break;
                }
                else
                {
                    string[] words = input.ToLower().Split(' ');
                    Product p1 = new Product();
                    p1.Quantity = Int32.Parse(words[0]);
                    p1.Price = Double.Parse(words[^1]);
                    p1.IsImported = words.Contains("imported");
                    p1.Name = string.Join(" ", words.Take(words.Length - 2));
                    p1.Category = GetCategory(input);
                    productList.Add(p1);
                }
            }
            return productList;
        }

        private GoodsType GetCategory(string input)
        {
            if (input.Contains("books") || input.Contains("book"))
                return GoodsType.Book;
            else if (input.Contains("chocolate") || input.Contains("chocolates"))
                return GoodsType.Food;
            else if (input.Contains("pills") || input.Contains("pill"))
                return GoodsType.Medical;
            else
                return GoodsType.Other;
        }
    }
}
