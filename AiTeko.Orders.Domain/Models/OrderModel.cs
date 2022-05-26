using AiTeko.Order.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiTeko.Orders.Domain.Models
{
    public class OrderModel : BaseOrderModel
    {
        public List<BaseProductModel> Products { get; set; }
    }

    public class GetOrderModel : BaseOrderModel
    {
        public List<ProductModel> Products { get; set; } = new List<ProductModel>();
    }

    public class BaseOrderModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
