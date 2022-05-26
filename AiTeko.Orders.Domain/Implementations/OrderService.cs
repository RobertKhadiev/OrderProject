using AiTeko.Order.DAL;
using AiTeko.Order.DAL.Entities;
using AiTeko.Orders.Domain.Interfaces;
using AiTeko.Orders.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AiTeko.Orders.Domain.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly OrderDbContext _context;

        public OrderService(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<long> Create(OrderModel orderModel)
        {
            // проверить все товары на наличие
            var products = _context.Products.ToList();
            decimal amount = 0;

            foreach (var product in orderModel.Products)
            {
                var productEntity = products.FirstOrDefault(x=> x.Id == product.Id);
                if (productEntity.Quantity < product.Quantity)
                {
                    throw new Exception("недостаточно товаров");
                }
                // посчитать сумму заказа
                amount += productEntity.Price*product.Quantity;
            }
            // создать Order
            var result = await _context.Orders.AddAsync(new OrderEntity
            {
                PriceAmount = amount,
                UserId = orderModel.UserId,
                PaymentType = orderModel.PaymentType
            });

            await _context.SaveChangesAsync();

            // создать OrderProducts
            foreach (var product in orderModel.Products)
            {
                await _context.OrderProducts.AddAsync(new OrderProductsEntity
                {
                    OrderId = result.Entity.Id,
                    ProductId = product.Id
                });

                // обновить Products, вычесть купленные товары

                var entity = products.FirstOrDefault(x => x.Id == product.Id);

                entity.Quantity -= product.Quantity;

                entity.UpdatedAt = DateTime.UtcNow;

                _context.Products.Update(entity);
            }

            await _context.SaveChangesAsync();

            return result.Entity.Id;
        }

        public List<GetOrderModel> GetAll()
        {
            var orderProducts = _context.OrderProducts.Include(x => x.Order).Include(x => x.Product).ToList();
            var orderModels = new List<GetOrderModel>();
            foreach (var op in orderProducts)
            {
                var productModel = new ProductModel
                {
                    Id = op.Product.Id,
                    Name = op.Product.Name,
                    Price = op.Product.Price,
                    Quantity = op.Product.Quantity,
                    Description = op.Product.Description
                };

                if (!orderModels.Any(x => x.Id == op.OrderId))
                {
                    var orderModel = new GetOrderModel
                    {
                        Id = op.Order.Id,
                        PaymentType = op.Order.PaymentType,
                        UserId = (long)op.Order.UserId
                    };

                    orderModel.Products.Add(productModel);
                    orderModels.Add(orderModel);
                }
                else
                {
                    orderModels.FirstOrDefault(x => x.Id == op.OrderId).Products.Add(productModel);
                }
            }
            return orderModels;
        }

        public GetOrderModel GetById(long id)
        {
            var orderProducts = _context.OrderProducts.Include(x => x.Order).Include(x => x.Product).Where(x => x.OrderId == id);
            var op = orderProducts.FirstOrDefault();
            var orderModel = new GetOrderModel
            {
                Id = op.Order.Id,
                PaymentType = op.Order.PaymentType,
                UserId = (long)op.Order.UserId
            };

            foreach (var item in orderProducts)
            {
                orderModel.Products.Add(new ProductModel
                {
                    Id = item.Product.Id,
                    Name = item.Product.Name,
                    Price = item.Product.Price,
                    Quantity = item.Product.Quantity,
                    Description = item.Product.Description
                });
            }
            return orderModel;
        }
    }
}
