using MF.Rb.Domain.Repository;
using MF.Rb.FakeRepository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MF.Rb.Api
{

    // Metoda rozszerzająca interfejsu IServiceCollection
    public static class ServicesExtentions
    {
        public static IServiceCollection AddRbServices(this IServiceCollection services)
        {
            services.AddSingleton<IReportRepository, FakeReportRepository>();
            services.AddScoped<ICustomerRepository, FakeCustomerRepository>();
            services.AddSingleton<IUserRepository, FakeUserRepository>();

            return services;
        }
    }
}
