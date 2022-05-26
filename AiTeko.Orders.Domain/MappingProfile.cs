using AiTeko.Order.DAL.Entities;
using AiTeko.Orders.Domain.Models;
using AutoMapper;

namespace AiTeko.Orders.Domain
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserEntity, UserModel>();
            CreateMap<UserModel, UserEntity>();
            CreateMap<ProductEntity, ProductModel>();
            CreateMap<ProductModel, ProductEntity>();
        }
    }
}
