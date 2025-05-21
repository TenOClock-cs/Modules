using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UtilsBot.Configuration;
using UtilsBot.Controllers;
using UtilsBot.Services;
using Telegram.Bot;

namespace UtilsBot;

public class Program
{
    static AppSettings BuildAppSettings()
    {
        return new AppSettings()
        {
            BotToken = Environment.GetEnvironmentVariable("BOT_TOKEN"),

        };
    }
    public static async Task Main()
    {
        Console.OutputEncoding = Encoding.Unicode;

        
        var host = new HostBuilder()
            .ConfigureServices((hostContext, services) => ConfigureServices(services)) 
            .UseConsoleLifetime() 
            .Build(); 

        Console.WriteLine("Сервис запущен");
        await host.RunAsync();
        Console.WriteLine("Сервис остановлен");
    }
    static void ConfigureServices(IServiceCollection services)
    {
        AppSettings appSettings = BuildAppSettings();
        services.AddSingleton(appSettings);
        services.AddTransient<DefaultController>();
        services.AddTransient<TextMessageController>();
        services.AddTransient<InlineKeyboardController>();
        services.AddSingleton<IStorage, MemoryStorage>();
        services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient(appSettings.BotToken));
        services.AddHostedService<UtilBot>();
    }
    
}