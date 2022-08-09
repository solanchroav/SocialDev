using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Boopstrap
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SocialDevDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SocialDev")));
            services.AddScoped<ICreateUserRepository, CreateUserRepository>();
            services.AddScoped<IUpdateUserRepository, UpdateUserRepository>();
            services.AddScoped<IGetUserByIdRepository, GetUserByIdRepository>();
            services.AddScoped<IGetUsersRepository, GetUsersRepository>();
            services.AddScoped<IUserAuthenticationRepository, UserAuthenticationRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
