using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repository
{
    public class CreateUserRepository : ICreateUserRepository
    {
        readonly SocialDevDbContext _context;

        public CreateUserRepository(SocialDevDbContext context) => _context = context;

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
        }
    }
}
