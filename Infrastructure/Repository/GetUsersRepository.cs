using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class GetUsersRepository : IGetUsersRepository
    {
        readonly SocialDevDbContext _context;
        public GetUsersRepository(SocialDevDbContext context) => _context = context;
        public async Task<List<UserAuth>> GetUsers()
        {
            
            var users = await _context.UserAuth.ToListAsync();
            return users;
        }

        public async Task<PaginatedList<UserAuth>> GetPaginatedUsers(int pageNumber, int pageSize)
        {
            //var users = await _context.Users
            //                    .Skip((pageNumber - 1) * pageSize)
            //                    .Take(pageSize)
            //                    .ToListAsync();
            //await _context.Set<User>()
            //    .Skip((pageNumber - 1) * pageSize)
            //    .Take(pageSize)
            //    .ToListAsync();

            var users = await PaginatedList<UserAuth>.CreateAsync(_context.Set<UserAuth>(), pageNumber, pageSize);
            return users;
        }
    }
}
