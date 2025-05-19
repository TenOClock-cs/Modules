using FFMpegCore;
using VoiceTexterBot.Configuration;
using VoiceTexterBot.Extensions;

namespace VoiceTexterBot.Utilities;

public class AudioConverter
{
    public static void TryConvert(string rootFolder, string inputFile, string outputFile)
    {
        GlobalFFOptions.Configure(options => options.BinaryFolder = Path.Combine(rootFolder,
            "ffmpeg-master-latest-win64-gpl-shared", "bin"));
        FFMpegArguments.FromFileInput(inputFile).
            OutputToFile(outputFile, true,options => options.WithFastStart()).ProcessSynchronously();
    }
}