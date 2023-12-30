using CustomLibrary.Services;
using Microsoft.EntityFrameworkCore;
using SekawanMedia.Data;
using SekawanMedia.Service.Infrastructure;
using SekawanMedia.Service.Interfaces;
using SekawanMedia.Service.Services;

namespace SekawanMedia
{
    public static class Extensions
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(builderOptions =>
            {
                builderOptions.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), options =>
                {
                    options.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(60), errorNumbersToAdd: null);
                });
            });
            return services;
        }
        public static IServiceCollection AddRequiredService(this IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<IPrivateUserIdService, PrivateUserIdService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return services;
        }
		public static IServiceCollection AddRepository(this IServiceCollection services)
		{
			services.AddScoped<IVehicleRepository, VehicleRepository>();
			services.AddScoped<IVehicleTypeRepository, VehicleTypeRepository>();
			services.AddScoped<IServiceHistoryRepository, ServiceHistoryRepository>();
			services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();

			return services;
		}

	}
}
