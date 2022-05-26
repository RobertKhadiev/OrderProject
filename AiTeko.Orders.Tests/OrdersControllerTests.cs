using AiTeko.Orders.Web.Controllers;
using System;
using Xunit;
using FakeItEasy;
using AiTeko.Orders.Domain.Interfaces;
using AiTeko.Orders.Domain.Models;
using AiTeko.Order.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using AiTeko.Orders.Domain.Implementations;
using Microsoft.EntityFrameworkCore.ChangeTracking;

/*
 * namespace AiTeko.Orders.Tests
{
    public class OrdersControllerTests
    {
        [Fact]
        public async Task GetOrderReturnCorrectNumberAsync()
        {
            // Arrange

            

            var dataStore = A.Fake<IOrderService>();

            var result = new OrderEntity { Id = 1, CreatedAt = DateTime.Now, PaymentType = PaymentType.Cash, PriceAmount = 5, UpdatedAt = DateTime.Now, UserId = 1 };

            var baseProduct = new BaseProductModel { Id = 1, Quantity = 2 };

            OrderModel om = new OrderModel { Id = 1, PaymentType = PaymentType.Cash, Products = new List<BaseProductModel> { baseProduct }, UserId = 1 };

            A.CallTo(() => dataStore.Create(om)).Returns(Task.FromResult(result.Id));

            var ordersController = new OrdersController(dataStore);


        }
    }
}
*/
