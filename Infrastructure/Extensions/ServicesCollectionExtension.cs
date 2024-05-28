using Application.Repositories;
using Infrastructure.DbContext;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class ServicesCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services , IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });


            services.AddScoped<IProperityRepo, ProperityRepository>();
            return services;
        }

    }
}
