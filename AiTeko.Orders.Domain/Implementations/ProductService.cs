using AiTeko.Order.DAL;
using AiTeko.Order.DAL.Entities;
using AiTeko.Orders.Domain.Interfaces;
using AiTeko.Orders.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiTeko.Orders.Domain.Implementations
{
    public class ProductService : IProductService
    {
        private readonly OrderDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(OrderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<long> Create(ProductModel productModel)
        {
            var entity = _mapper.Map<ProductEntity>(productModel);

            var result = await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public List<ProductModel> GetAll()
        {
            var orders = _context.Products.ToList();
            return _mapper.Map<List<ProductModel>>(orders);
        }

        public ProductModel GetById(long id)
        {
            var order = _context.Products.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<ProductModel>(order);
        }
    }
}
