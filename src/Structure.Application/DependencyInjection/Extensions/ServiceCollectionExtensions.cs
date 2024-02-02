using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Structure.Application.Behaviors;

namespace Structure.Application.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConfigureMediatR(this IServiceCollection service)
            => service.AddMediatR(o => o.RegisterServicesFromAssembly(AssemblyReference.Assembly))
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>))
                .AddValidatorsFromAssembly(Contract.AssemblyReference.Assembly, includeInternalTypes: true);
    }
}