﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

#if ANDROID || IOS
using banditoth.MAUI.JailbreakDetector;
#endif

namespace JailBreakDetectionProj
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

            #if ANDROID || IOS
            // Configure jailbreak protection for Android/iOS only
            builder.ConfigureJailbreakProtection(configuration =>
            {
                configuration.MaximumPossibilityPercentage = 20;
                configuration.MaximumWarningCount = 1;
                configuration.CanThrowException = true;
            });
            #endif

            #if DEBUG
            builder.Logging.AddDebug();
            #endif

            // Register services for all platforms
            builder.Services.AddSingleton<IDialogService, DialogService>();
            builder.Services.AddTransient<MainViewModel>();

            return builder.Build();
        }
    }
}