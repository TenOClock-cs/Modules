using System.Text;
using Newtonsoft.Json.Linq;
using VoiceTexterBot.Extensions;
using Vosk;

namespace VoiceTexterBot.Utilities;

public static class SpeechDetector
{
    public static string DetectSpeech(string rootFolder, string audioPath, float inputBitrate, string languageCode)
    {
        Vosk.Vosk.SetLogLevel(0);
        var modelPath = Path.Combine(rootFolder, "voice-models", $"vosk-model-small-{languageCode.ToLower()}");
        Model model = new(modelPath);
        return GetWords(model, audioPath, inputBitrate);
    }

    private static string GetWords(Model model, string audioPath, float inputBitrate)
    {
        VoskRecognizer vr = new (model, inputBitrate);
        vr.SetMaxAlternatives(0);
        vr.SetWords(true);
        StringBuilder textBuffer = new();
        using (Stream source = File.OpenRead(audioPath))
        {
            byte[] buffer = new byte[4096];
            int bytesRead;
            while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
            {
                if (vr.AcceptWaveform(buffer, bytesRead))
                {
                    var sentenceJson = vr.Result();
                    JObject sentenceObj = JObject.Parse(sentenceJson);
                    string? sentence = (string)sentenceObj["text"];
                    textBuffer.Append(StringExtensions.UppercaseFirst(sentence) + ". ");
                    
                }
            }
        }
        var finalSentence = vr.FinalResult();
        JObject finalSentenceObj = JObject.Parse(finalSentence);
        textBuffer.Append((string)finalSentenceObj["text"]);
        return textBuffer.ToString();
    }
}