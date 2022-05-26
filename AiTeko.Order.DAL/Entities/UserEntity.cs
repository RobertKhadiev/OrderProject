using Chatty.DataAccess.Entities;
using System;
namespace AiTeko.Order.DAL.Entities
{
    public class UserEntity : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
