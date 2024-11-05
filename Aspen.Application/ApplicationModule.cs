using Aspen.Application.Commands.InsertComments;
using Aspen.Application.Commands.InsertCompany;
using Aspen.Application.Models;
using Aspen.Application.Services;
using Aspen.Application.Services.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
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
                .AddValidation()
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

        private static IServiceCollection AddValidation (this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation().AddValidatorsFromAssemblyContaining<InsertCompanyCommand>();

            return services;
        }

}
}
