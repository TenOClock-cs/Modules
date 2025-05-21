using UtilsBot.Models;
using UtilsBot.Services;
using UtilsBot.Utils;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace UtilsBot.Controllers;

public class TextMessageController
{
    private readonly ITelegramBotClient _telegramClient;
    private readonly IStorage _storage;

    public TextMessageController(ITelegramBotClient telegramBotClient, IStorage storage)
    {
        _telegramClient = telegramBotClient;
        _storage = storage;
    }

    public async Task Handle(Message message, CancellationToken ct)
    {
        string botFunc = _storage.GetSession(message.Chat.Id).BotFunc;
        string returnText = string.Empty;
        switch (message.Text)
        {
            case "/start":
                var buttons = new List<InlineKeyboardButton[]>();
                buttons.Add(new[]
                {
                    InlineKeyboardButton.WithCallbackData($" Подсчет символов", $"charCount"),
                    InlineKeyboardButton.WithCallbackData($" Суммирование чисел", $"summNumbers")
                });
                await _telegramClient.SendMessage(message.Chat.Id, $"<b>  Наш бот что-то умеет </b>",
                    cancellationToken: ct,
                    parseMode: ParseMode.Html, replyMarkup: new InlineKeyboardMarkup(buttons));
                break;
            default:
                switch (botFunc)
                {
                    case "charCount":
                        returnText = "Количество символов: " + MessageProcessor.CharsCount(message.Text);
                        break;
                    case "summNumbers":
                        try
                        {
                            returnText = "Сумма цифр: " + MessageProcessor.SummNumbers(message.Text);
                        }
                        catch (FormatException e)
                        {
                            returnText = e.Message;
                        }

                        break;
                    default:
                        returnText = "Error cause";
                        break;
                }

                await _telegramClient.SendMessage(message.Chat.Id, returnText, cancellationToken: ct);
                break;
        }
    }
}