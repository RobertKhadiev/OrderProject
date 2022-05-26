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
    public class UserService : IUserService
    {
        private readonly OrderDbContext _context;
        private readonly IMapper _mapper;

        public UserService(OrderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<UserModel> GetAll()
        {
            var users = _context.Users.ToList();
            return _mapper.Map<List<UserModel>>(users);
        }
        public UserModel GetById(long userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            return _mapper.Map<UserModel>(user);
        }
        public async Task<long> Create(UserModel userModel)
        {
            var user = _mapper.Map<UserEntity>(userModel);
            var result = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }
    }
}
