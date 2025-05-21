using Telegram.Bot;
using Telegram.Bot.Types;

namespace UtilsBot.Controllers;

public class DefaultController
{
    private readonly ITelegramBotClient _telegramClient;

    public DefaultController(ITelegramBotClient telegramBotClient)
    {
        _telegramClient = telegramBotClient;
    }
    public async Task Handle(Message message, CancellationToken ct)
    {
        Console.WriteLine($"Контроллер {GetType().Name} получил сообщение");
        await _telegramClient.SendMessage(message.Chat.Id, $"Получено сообщение не поддерживаемого формата", cancellationToken: ct);
    }
}