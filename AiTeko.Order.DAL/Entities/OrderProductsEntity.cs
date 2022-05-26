using Chatty.DataAccess.Entities;

namespace AiTeko.Order.DAL.Entities
{
    public class OrderProductsEntity : BaseEntity
    {
        public long? OrderId { get; set; }
        public long? ProductId { get; set; }
        public OrderEntity Order { get; set; }
        public ProductEntity Product { get; set; }
    }
}
