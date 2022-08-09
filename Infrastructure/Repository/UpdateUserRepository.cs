using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repository
{
    public class UpdateUserRepository : IUpdateUserRepository
    {
        readonly SocialDevDbContext _context;

        public UpdateUserRepository(SocialDevDbContext context) => _context = context;

        public void UpdateUser(UserAuth user)
        {
            _context.UserAuth.Update(user);
        }
    }
}
