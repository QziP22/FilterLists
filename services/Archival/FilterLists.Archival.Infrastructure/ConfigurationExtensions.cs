﻿using System;
using FilterLists.Archival.Infrastructure.Clients;
using FilterLists.Archival.Infrastructure.Logging;
using FilterLists.Archival.Infrastructure.Persistence;
using FilterLists.Archival.Infrastructure.Scheduling;
using FilterLists.Directory.Api.Contracts;
using FilterLists.SharedKernel.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FilterLists.Archival.Infrastructure
{
    public static class ConfigurationExtensions
    {
        public static IHostBuilder UseInfrastructure(this IHostBuilder hostBuilder)
        {
            return hostBuilder.UseLogging();
        }

        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            _ = configuration ?? throw new ArgumentNullException(nameof(configuration));

            services.AddArchivalLogging(configuration);
            services.AddSchedulingServices(configuration);
            services.AddDirectoryApiClient(configuration);
            services.AddClients();
            services.AddPersistenceServices(configuration);
        }

        public static void UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseArchivalLogging();
            app.UseScheduling();
        }
    }
}
