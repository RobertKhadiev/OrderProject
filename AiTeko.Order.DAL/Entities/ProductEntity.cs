using Chatty.DataAccess.Entities;

namespace AiTeko.Order.DAL.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
