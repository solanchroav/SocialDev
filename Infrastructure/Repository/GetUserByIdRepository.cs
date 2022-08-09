using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repository
{
    public class GetUserByIdRepository : IGetUserByIdRepository
    {
        readonly SocialDevDbContext _context;

        public GetUserByIdRepository(SocialDevDbContext context) => _context = context;

        public async Task<UserAuth> GetUserById(int userId)
        {
            var user = await _context.UserAuth.FindAsync(userId);
            return user;
        }
    }
}
