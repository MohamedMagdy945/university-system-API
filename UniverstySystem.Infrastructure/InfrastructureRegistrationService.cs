using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UniversitySystem.Application.Interfaces;
using UniverstySystem.Infrastructure.Persistence;
using UniverstySystem.Infrastructure.Repositories;
using UniverstySystem.Infrastructure.Service;
using UniverstySystem.Infrastructure.Services;

namespace UniverstySystem.Infrastructure
{
    public static class InfrastructureRegistrationService
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddSingleton<ITokenGenerator, TokenGenerator>();


            services.AddScoped<IAppDbContext, AppDbContext>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IRoleService, RoleService>();

            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
