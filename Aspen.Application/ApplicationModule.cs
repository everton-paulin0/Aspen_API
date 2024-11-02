using Aspen.Application.Commands.InsertComments;
using Aspen.Application.Commands.InsertCompany;
using Aspen.Application.Models;
using Aspen.Application.Services;
using Aspen.Application.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace Aspen.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services
                .AddServices()
                .AddHandlers();

            return services;
        }
        
        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICompanyService, CompanyService>();
            
            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            config.RegisterServicesFromAssemblyContaining<InsertCompanyCommand>());

            services.AddTransient<IPipelineBehavior<InsertCompanyCommand, ResultViewModel<int>>, ValidateInsertCompanyCommand>();

            return services;

        }

}
}
