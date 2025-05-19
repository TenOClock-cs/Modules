using Telegram.Bot;
using Telegram.Bot.Types;
using VoiceTexterBot.Configuration;
using VoiceTexterBot.Services;

namespace VoiceTexterBot.Controllers;

public class VoiceMessageController
{
    private readonly ITelegramBotClient _telegramClient;
    private readonly AppSettings _appSettings;
    private readonly IFileHandler _audiofileHandler;
    private readonly IStorage _storage;

    public VoiceMessageController(ITelegramBotClient telegramBotClient,  AppSettings appSettings, 
        IFileHandler audiofileHandler, IStorage storage)
    {
        _appSettings = appSettings;
        _telegramClient = telegramBotClient;
        _audiofileHandler = audiofileHandler;
        _storage = storage;
        
    }
    public async Task Handle(Message message, CancellationToken ct)
    {
        var fileId = message.Voice?.FileId;
        string languageCode = _storage.GetSession(message.Chat.Id).LanguageCode;
        string messageTextDownloaded = "Голосовое сообщение загружено";
        
        if (fileId == null)
            return;
        await _audiofileHandler.Download(fileId, ct);
        await _telegramClient.SendMessage(message.Chat.Id, messageTextDownloaded, cancellationToken: ct);
        var result = _audiofileHandler.Process(languageCode);
        await _telegramClient.SendMessage(message.Chat.Id, result, cancellationToken: ct);
        
    }
    
}