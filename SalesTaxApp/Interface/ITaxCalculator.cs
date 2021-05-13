using SalesTaxApp.Models;
using System.Collections.Generic;

namespace SalesTaxApp.Interface
{
    interface ITaxCalculator
    {
        void CalculateTax(List<Product> products);
    }
}
