using AiTeko.Orders.Domain.Interfaces;
using AiTeko.Orders.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AiTeko.Orders.Web.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _orderService.GetAll();

            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        public IActionResult GetById(long orderId)
        {
            var order = _orderService.GetById(orderId);

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderModel orderModel)
        {
            var orderId = await _orderService.Create(orderModel);
            return Ok(orderId);
        }
    }
}
