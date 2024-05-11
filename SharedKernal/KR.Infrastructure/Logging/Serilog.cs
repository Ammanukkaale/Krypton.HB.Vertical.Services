﻿using System;
using KR.Infrastructure.Logging.Enricher;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;

namespace KR.Infrastructure.Logging
{
	public static class Serilog
	{
		public static void RegisterLogger(this WebApplicationBuilder builder)
		{
            builder.Logging.ClearProviders();
            builder.Services.AddTransient<ILogEventEnricher, HttpContextLogEnricher>();
            builder.Host.UseSerilog((builderContext, serviceProvider, config) =>
            {
                config.ReadFrom.Configuration(builderContext.Configuration)
                    .ReadFrom.Services(serviceProvider)                
                    .Enrich.FromLogContext();               
            });
        }
	}
}

