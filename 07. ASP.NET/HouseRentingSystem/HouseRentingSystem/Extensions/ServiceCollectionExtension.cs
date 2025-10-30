using HouseRentingSystem.Core.Contracts.AgentServices;
using HouseRentingSystem.Core.Contracts.HouseServices;
using HouseRentingSystem.Core.Contracts.StatisticServices;
using HouseRentingSystem.Core.Services.AgentServices;
using HouseRentingSystem.Core.Services.HouseServices;
using HouseRentingSystem.Core.Services.StatisticService;
using HouseRentingSystem.Infrastructure.Data;
using HouseRentingSystem.Infrastructure.Data.Common;
using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IHouseService, HouseService>();
        services.AddScoped<IAgentService, AgentService>();
        services.AddScoped<IStatisticService, StatisticService>();
        
        return services;
    }

    public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DefaultConnection") ??
                               throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<HouseRentingDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IRepository, Repository>();
        
        services.AddDatabaseDeveloperPageExceptionFilter();


        return services;
    }

    public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
    {
        services
            .AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<HouseRentingDbContext>();

        return services;
    }
}