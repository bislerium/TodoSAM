using Microsoft.Extensions.Logging;
using TodoSAM.Models;
using TodoSAM.Persistence;
using TodoSAM.Services;
using TodoSAM.Utils;

namespace TodoSAM
{
    public static class MauiProgram
    {
        public static async Task<MauiApp> CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            await Migrator.Migrate();
            
            builder.Services.AddTransient(sp => RepositoryResolver.GetTodoTaskRepository());   

            return builder.Build();
        }
    }
}
