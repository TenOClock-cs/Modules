using Telegram.Bot;
using Telegram.Bot.Types;
using VoiceTexterBot.Services;

namespace VoiceTexterBot.Controllers;

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
        _memoryStorage.GetSession(callbackQuery.From.Id).LanguageCode = callbackQuery.Data;
        
        string languageText = callbackQuery.Data switch
        {
            "ru" => " Русский",
            "en" => " Английский",
            _ => String.Empty
        };
        string messageText = $"<b>Язык аудио - {languageText}.{Environment.NewLine}</b>" +
                             $"{Environment.NewLine}Можно поменять в главном меню.";
        
        await _telegramClient.SendMessage(callbackQuery.From.Id, messageText, cancellationToken: ct);
    }
}