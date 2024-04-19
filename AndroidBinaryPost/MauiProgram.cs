using Microsoft.Extensions.Logging;

namespace AndroidBinaryPost
{
    public static class MauiProgram
    {
        public static string ServerAddress = "d18f-65-128-160-145.ngrok-free.app";
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

            // this works on Windows and fails on Android
            //builder.Services.AddScoped<HttpClient>();

            // this works on Android (and Windows)
            builder.Services.AddScoped<HttpClient>((p) => new HttpClient(new SocketsHttpHandler()));

            builder.Services.AddTransient<MainPage>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
