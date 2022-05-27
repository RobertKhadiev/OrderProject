using System;
using Xunit;
using FakeItEasy;
using AiTeko.Orders.Domain.Models;
using AiTeko.Order.DAL.Entities;
using System.Collections.Generic;
using AiTeko.Orders.Domain.Implementations;
using AiTeko.Order.DAL;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System.Linq;
using FluentAssertions;

namespace AiTeko.Orders.Tests
{
    public class OrdersServiceTests
    {

        // test Example
        [Fact]
        public void CreateOrder_CheckEnoughProducts_ThrowException()
        {
            // Arrange
            var products = new List<ProductEntity>() { new ProductEntity { Id = 1, Quantity = 1 } };
            var mockApplications = Substitute.For<DbSet<ProductEntity>, IQueryable<ProductEntity>>();
            ((IQueryable<ProductEntity>)mockApplications).Provider.Returns(products.AsQueryable().Provider);
            ((IQueryable<ProductEntity>)mockApplications).Expression.Returns(products.AsQueryable().Expression);
            ((IQueryable<ProductEntity>)mockApplications).ElementType.Returns(products.AsQueryable().ElementType);
            ((IQueryable<ProductEntity>)mockApplications).GetEnumerator().Returns(products.AsQueryable().GetEnumerator());

            var orderEntity = new OrderEntity { Id = 1, CreatedAt = DateTime.Now, PaymentType = PaymentType.Cash, PriceAmount = 5, UpdatedAt = DateTime.Now, UserId = 1 };
            var baseProduct = new BaseProductModel { Id = 1, Quantity = 2 };
            var om = new OrderModel { Id = 1, PaymentType = PaymentType.Cash, Products = new List<BaseProductModel> { baseProduct }, UserId = 1 };

            var mockContext = Substitute.For<OrderDbContext>();
            mockContext.Products = mockApplications;
            var service = new OrderService(mockContext);

            // Act
            Action act = () => service.Create(om).GetAwaiter().GetResult();

            // Assert

            act.Should().Throw<Exception>();
        }


    }
}
