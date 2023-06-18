﻿using Microsoft.EntityFrameworkCore;
using Repositories;

namespace StoreApp.Infrastructure.Extensions
{
    public static class ApplicationExtension
    {

        public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
        {

            RepositoryContext context=app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<RepositoryContext>();

            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();

            }

        }

        public static void ConfigureLocalization(this IApplicationBuilder app)
        {
            app.UseRequestLocalization(options =>
            {
                options.AddSupportedCultures("tr-TR", "en-GB")
                       .AddSupportedUICultures("tr-TR", "en-GB")
                       .SetDefaultCulture("tr-TR");
            });
        }

    }
}
