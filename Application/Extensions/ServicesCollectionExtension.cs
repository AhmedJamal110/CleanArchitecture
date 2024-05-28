using Application.PiplineBehaviour;
using Application.ProfilesMapping;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class ServicesCollectionExtension
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {

           /// services.AddAutoMapper(typeof(MappingProfile));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPiplelineBehaviour<,>));

        }

    }
}
