using Chatty.DataAccess.Entities;

namespace AiTeko.Order.DAL.Entities
{
    public class OrderEntity : BaseEntity
    {
        public long? UserId  { get; set; }
        public decimal PriceAmount { get; set; }
        public PaymentType PaymentType { get; set; }
    }

    public enum PaymentType
    {
        Cash = 1, CreditCard
    }
}
