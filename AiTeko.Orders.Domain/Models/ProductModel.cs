namespace AiTeko.Orders.Domain.Models
{
    public class ProductModel : BaseProductModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }

    public class BaseProductModel
    {
        public long Id { get; set; }
        public int Quantity { get; set; }
    }
}
