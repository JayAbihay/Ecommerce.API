using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using eCommerce.Core.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {

            services.AddSingleton<IUsersService, UsersService>();
            services.AddSingleton<LoginRequestValidator>();
            services.AddSingleton<RegisterRequestValidator>();
            return services;
        }
    }
}
