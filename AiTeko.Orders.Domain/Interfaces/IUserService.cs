using AiTeko.Order.DAL.Entities;
using AiTeko.Orders.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiTeko.Orders.Domain.Interfaces
{
    public interface IUserService
    {
        public List<UserModel> GetAll();
        public UserModel GetById(long userId);
        public Task<long> Create(UserModel userModel);
    }
}
