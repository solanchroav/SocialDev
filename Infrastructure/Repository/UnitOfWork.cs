using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly SocialDevDbContext _context;
        readonly ILogger<UnitOfWork> _logger;

        public UnitOfWork(SocialDevDbContext context, ILogger<UnitOfWork> logger) => (_context, _logger) = (context, logger);

        public async Task<int> SaveChanges()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }
        }
    }
}
