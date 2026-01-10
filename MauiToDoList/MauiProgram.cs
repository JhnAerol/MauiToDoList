using MauiToDoList.ViewModels;
using MauiToDoList.Views;
using Microsoft.Extensions.Logging;

namespace MauiToDoList
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
                    fonts.AddFont("Gagalin-Regular.otf", "Gagalin");
                });

            builder.Services.AddSingleton<TaskListPageViewModel>().AddSingleton<TaskListPage>();
            builder.Services.AddSingleton<ArchivePage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
