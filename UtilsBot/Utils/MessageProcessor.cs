namespace UtilsBot.Utils;

public static class MessageProcessor
{
    public static int SummNumbers(string message)
    {
        string[] arr = message.Split(" ");
        int result = 0;
        foreach(string s in arr)
        {
            result += int.Parse(s);
        }
        return result;
    }

    public static int CharsCount(string message)
    {
        return message.Length;
    }
}