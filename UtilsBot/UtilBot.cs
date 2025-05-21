using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using UtilsBot.Controllers;

namespace UtilsBot;

public class UtilBot : BackgroundService
{
    private ITelegramBotClient _telegramClient;

    private InlineKeyboardController _inlineKeyboardController;
    private TextMessageController _textMessageController;
    private DefaultController _defaultController;
    
    public UtilBot(
        ITelegramBotClient telegramClient,
        InlineKeyboardController inlineKeyboardController,
        TextMessageController textMessageController,
        DefaultController defaultController)
    {
        _telegramClient = telegramClient;
        _inlineKeyboardController = inlineKeyboardController;
        _textMessageController = textMessageController;
        _defaultController = defaultController;
    }
    async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                await _inlineKeyboardController.Handle(update.CallbackQuery, cancellationToken);
                return;
            }
            if (update.Type == UpdateType.Message)
            {
                switch (update.Message!.Type)
                {
                    case MessageType.Text:
                        await _textMessageController.Handle(update.Message, cancellationToken);
                        return;
                    default:
                        await _defaultController.Handle(update.Message, cancellationToken);
                        return;
                }
            }
        }

        Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            
            var errorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };
            Console.WriteLine(errorMessage);
            Console.WriteLine("Ожидаем 10 секунд перед повторным подключением.");
            Thread.Sleep(10000);
            return Task.CompletedTask;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _telegramClient.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                new ReceiverOptions()
                {
                    AllowedUpdates = { }
                }, 
                cancellationToken: stoppingToken);

            Console.WriteLine("Бот запущен");
            return Task.CompletedTask;
        }
}