using SalesTaxApp.Interface;
using SalesTaxApp.Models;
using System;
using System.Collections.Generic;

namespace SalesTaxApp.Implementation
{
    class ReceiptPrinter : IReceiptPrinter
    {
        public void PrintReceipt(List<Product> products)
        {
            Console.WriteLine("\n-------------Printing Receipt---------------\n");
            foreach (var product in products)
            {
                Console.WriteLine(product.Name + ": {0}", GetSum(product.Price, product.TaxPrice));

            }
        }

        private double GetSum(double price, double taxPrice)
        {
            return Math.Round(price + taxPrice, 2);
        }
    }
}
