using Telegram.Bot;
using VoiceTexterBot.Configuration;
using VoiceTexterBot.Utilities;
namespace VoiceTexterBot.Services;

public class AudioFileHandler : IFileHandler
{
    private readonly AppSettings _appSettings;
    private readonly ITelegramBotClient _telegramBotClient;
    
    public AudioFileHandler(ITelegramBotClient telegramBotClient, AppSettings appSettings)
    {
        _appSettings = appSettings;
        _telegramBotClient = telegramBotClient;
    }
    public async Task Download(string fileId, CancellationToken ct)
    {
        // Генерируем полный путь файла из конфигурации
        string inputAudioFilePath = Path.Combine(_appSettings.DownloadsFolder, $"{_appSettings.AudioFileName}.{_appSettings.InputAudioFormat}");

        using (FileStream destinationStream = File.Create(inputAudioFilePath))
        {
            // Загружаем информацию о файле
            var file = await _telegramBotClient.GetFile(fileId, ct);
            if (file.FilePath == null)
                return;

            // Скачиваем файл
            await _telegramBotClient.DownloadFile(file.FilePath, destinationStream, ct);
        }
    }
    public string Process(string languageCode)
    {
        string inputAudioPath = Path.Combine(_appSettings.DownloadsFolder, 
            $"{_appSettings.AudioFileName}.{_appSettings.InputAudioFormat}");
        string outputAudioPath = Path.Combine(_appSettings.DownloadsFolder, 
            $"{_appSettings.AudioFileName}.{_appSettings.OutputAudioFormat}");

        Console.WriteLine("Начинаем конвертацию...");
        AudioConverter.TryConvert(_appSettings.RootFolder,inputAudioPath, outputAudioPath);
        Console.WriteLine("Файл конвертирован");
        Console.WriteLine("Начинаем распознавание...");
        var speechText = SpeechDetector.DetectSpeech(_appSettings.RootFolder,outputAudioPath, 
            _appSettings.InputBitrate, languageCode);
        Console.WriteLine("Файл распознан.");
        return speechText;
    }
    
}