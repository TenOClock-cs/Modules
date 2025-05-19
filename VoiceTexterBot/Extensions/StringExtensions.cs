namespace VoiceTexterBot.Extensions;

public class StringExtensions
{
    public static string UppercaseFirst(string s)
    {
        if (string.IsNullOrEmpty(s))
            return string.Empty;

        return char.ToUpper(s[0]) + s.Substring(1);
    }
}