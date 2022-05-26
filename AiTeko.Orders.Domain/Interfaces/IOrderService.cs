using AiTeko.Order.DAL.Entities;
using AiTeko.Orders.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AiTeko.Orders.Domain.Interfaces
{
    public interface IOrderService
    {
        List<GetOrderModel> GetAll();
        GetOrderModel GetById(long orderId);
        Task<long> Create(OrderModel orderModel);

    }
}
