using Application.Interfaces;
using Application.Services;
using Domain.Contracts.Repository;
using Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application
            services.AddScoped<IAeronaveApplication, AeronaveApplication>();

            //Infra - Data
            services.AddScoped<IAeronaveRepository, AeronaveRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<AeronaveContext>();
        }
    }
}