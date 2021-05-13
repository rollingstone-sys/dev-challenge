using SalesTaxApp.Models;
using System.Collections.Generic;

namespace SalesTaxApp.Interface
{
    interface IProductParser
    {
        List<Product> GetProducts();
    }
}
