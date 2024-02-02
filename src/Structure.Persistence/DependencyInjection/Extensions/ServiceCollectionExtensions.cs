﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Structure.Domain.Entities.Identity;
using Structure.Persistence.DependencyInjection.Options;

namespace Structure.Persistence.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSqlConfiguration(this IServiceCollection services)
        {
            services.AddDbContextPool<DbContext, ApplicationDbContext>((provider, builder) =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                var options = provider.GetRequiredService<IOptionsMonitor<SqlServerRetryOptions>>();

                builder
                .EnableDetailedErrors(true)
                .EnableSensitiveDataLogging(true)
                .UseLazyLoadingProxies(true) // => If UseLazyLoadingProxies, all of the navigation fields should be VIRTUAL
                .UseSqlServer(
                    connectionString: configuration.GetConnectionString("SqlServer"),
                    sqlServerOptionsAction: optionsBuilder
                            => optionsBuilder.ExecutionStrategy(
                                    dependencies => new SqlServerRetryingExecutionStrategy(
                                        dependencies: dependencies,
                                        maxRetryCount: options.CurrentValue.MaxRetryCount,
                                        maxRetryDelay: options.CurrentValue.MaxRetryDelay,
                                        errorNumbersToAdd: options.CurrentValue.ErrorNumbersToAdd))
                                .MigrationsAssembly(typeof(ApplicationDbContext).Assembly.GetName().Name));

                builder
                .EnableDetailedErrors(true)
                .EnableSensitiveDataLogging(true)
                .UseLazyLoadingProxies(true) // => If UseLazyLoadingProxies, all of the navigation fields should be VIRTUAL
                .UseSqlServer(
                    connectionString: configuration.GetConnectionString("SqlServer"),
                        sqlServerOptionsAction: optionsBuilder
                            => optionsBuilder
                            .MigrationsAssembly(typeof(ApplicationDbContext).Assembly.GetName().Name));
            });

            services.AddIdentityCore<AppUser>(opt =>
            {
                opt.Lockout.AllowedForNewUsers = true; // Default true
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2); // Default 5
                opt.Lockout.MaxFailedAccessAttempts = 3; // Default 5
            })
                .AddRoles<AppRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Lockout.AllowedForNewUsers = true; // Default true
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2); // Default 5
                options.Lockout.MaxFailedAccessAttempts = 3; // Default 5
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                options.Lockout.AllowedForNewUsers = true;
            });
        }

        public static OptionsBuilder<SqlServerRetryOptions> ConfigureSqlServerRetryOptions(this IServiceCollection services, IConfigurationSection section)
            => services
                .AddOptions<SqlServerRetryOptions>()
                .Bind(section)
                .ValidateDataAnnotations()
                .ValidateOnStart();
    }
}