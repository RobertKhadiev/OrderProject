using AiTeko.Order.DAL.Entities;
using AiTeko.Orders.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiTeko.Orders.Domain.Interfaces
{
    public interface IProductService
    {
        List<ProductModel> GetAll();
        ProductModel GetById(long productId);
        Task<long> Create(ProductModel productModel);
    }
}
