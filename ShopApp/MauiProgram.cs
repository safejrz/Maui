﻿using Microsoft.Extensions.Logging;
using ShopApp.DataAccess;
using ShopApp.Services;
using ShopApp.ViewModels;
using ShopApp.Views;

namespace ShopApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            Routing.RegisterRoute(nameof(ProductDetailPage), typeof(ProductDetailPage));
            Routing.RegisterRoute(nameof(HelpSupportDetailPage), typeof(HelpSupportDetailPage));

            builder.Services.AddSingleton<INavigationService,  NavigationService>();
            builder.Services.AddTransient<HelpSupportViewModel>();
            builder.Services.AddTransient<HelpSupportPage>();
            builder.Services.AddTransient<HelpSupportDetailViewModel>();
            builder.Services.AddTransient<HelpSupportDetailPage>();

            var dbContext = new ShopDbContext();
            dbContext.Database.EnsureCreated();
            dbContext.Dispose();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
