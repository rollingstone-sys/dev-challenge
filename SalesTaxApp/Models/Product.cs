
namespace SalesTaxApp.Models
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsImported { get; set; }
        public int Quantity { get; set; }
        public GoodsType Category { get; set; }
        public double TaxPrice { get; set; }
    }

    public enum GoodsType
    {
        Book = 1,
        Food = 2,
        Medical = 3,
        Other = 4
    }
}
