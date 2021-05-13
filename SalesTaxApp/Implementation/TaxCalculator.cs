using SalesTaxApp.Interface;
using SalesTaxApp.Models;
using System.Collections.Generic;

namespace SalesTaxApp.Implementation
{
    class TaxCalculator : ITaxCalculator
    {
        public void CalculateTax(List<Product> products)
        {
            double tax;
            foreach (var product in products)
            {
                tax = 0;
                if (product.IsImported)
                    tax = product.Quantity * product.Price * 0.05;

                if(product.Category == GoodsType.Other)
                    tax += product.Quantity * product.Price * 0.1;

                product.TaxPrice = tax;

            }
        }
    }
}
