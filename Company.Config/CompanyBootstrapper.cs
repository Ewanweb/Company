using Company.Application._shared;
using Company.Application._shared.FileUtil.Interfaces;
using Company.Application._shared.FileUtil.Services;
using Company.Domain.Repositories;
using Company.Domain.Users;
using Company.Facade.Services;
using Company.Facade.Users;
using Company.Infrast;
using Company.Infrast.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Config
{
    public static class CompanyBootstrapper
    {
        public static IServiceCollection Init(IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("Defualt")));


            services.AddIdentity<User, IdentityRole<Guid>>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IUserFacade, UserFacade>();
            services.AddScoped<IServiceFacade, ServiceFacade>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IConsulationRepository, ConsulationRepository>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Directories).Assembly));

            return services;
        }
    }
}
