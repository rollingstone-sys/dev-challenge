using SalesTaxApp.Models;
using System.Collections.Generic;

namespace SalesTaxApp.Interface
{
    interface IReceiptPrinter
    {
        void PrintReceipt(List<Product> products);
    }
}
