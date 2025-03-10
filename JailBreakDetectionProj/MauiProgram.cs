using banditoth.MAUI.JailbreakDetector;
using banditoth.MAUI.JailbreakDetector.Interfaces;
using Microsoft.Extensions.Logging;



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
                }).ConfigureJailbreakProtection(configuration =>
                {
                    configuration.MaximumPossibilityPercentage = 20;
                    configuration.MaximumWarningCount = 1;
                    configuration.CanThrowException = true;
                });
#if DEBUG
            builder.Logging.AddDebug();
            builder.Services.AddSingleton<IDialogService, DialogService>();

            builder.Services.AddTransient<MainViewModel>();
#endif

            return builder.Build();
        }
    }
}
