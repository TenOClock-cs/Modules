using UtilsBot.Services;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace UtilsBot.Controllers;

public class InlineKeyboardController
{
    private readonly ITelegramBotClient _telegramClient;
    private readonly IStorage _memoryStorage;
    public InlineKeyboardController(ITelegramBotClient telegramBotClient, IStorage memoryStorage)
    {
        _telegramClient = telegramBotClient;
        _memoryStorage = memoryStorage;
        
    }
    public async Task Handle(CallbackQuery? callbackQuery, CancellationToken ct)
    {
        Console.WriteLine($"Контроллер {GetType().Name} обнаружил нажатие на кнопку");
        if (callbackQuery?.Data == null)
            return;
        _memoryStorage.GetSession(callbackQuery.From.Id).BotFunc = callbackQuery.Data;
        
        string botFunc = callbackQuery.Data switch
        {
            "charCount" => " Подсчет количества символов в сообщении",
            "summNumbers" => " Суммирование чисел",
            _ => String.Empty
        };
        string messageText = $"<b>Текущая функция - {botFunc}.</b>" +
                             $"{Environment.NewLine}Можно поменять в главном меню.";
        
        await _telegramClient.SendMessage(callbackQuery.From.Id, messageText, parseMode: ParseMode.Html,cancellationToken: ct);
    }
}