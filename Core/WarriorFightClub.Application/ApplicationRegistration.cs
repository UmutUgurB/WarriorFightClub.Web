using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorFightClub.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ApplicationServiceRegistration).Assembly);

            services.AddAutoMapper(typeof(ApplicationServiceRegistration).Assembly);

            services.AddValidatorsFromAssembly(typeof(ApplicationServiceRegistration).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(WarriorFightClub.Application.Behaviors.ValidationBehavior<,>));

            return services;
        }
    }
}
