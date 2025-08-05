using System.Collections.Generic;
using System.Diagnostics;

public class Module13
{
    public static String readText(String filePath)
    {
        return File.ReadAllText(filePath);
    }

    public static void stopWatchTest(List<string> stringList, LinkedList<string> linkedStringList)
    {
       Stopwatch stopwatch = new Stopwatch();
       int afterPosition = stringList.Count/2;
       stopwatch.Start();
       stringList.Insert(0, "parabellum");
       stopwatch.Stop();
       Console.WriteLine($"Inserting into LIST: {stopwatch.Elapsed}");
       stopwatch.Reset();
       stopwatch.Start();
       linkedStringList.AddFirst("parabellum");
       Console.WriteLine($"Inserting into LinkedLIST: {stopwatch.Elapsed}");
    }

    public static string removeAllPunctuations(String str)
    {
        return new string(str.Where(c => !char.IsPunctuation(c)).ToArray());
    }

    public static List<string> makeList(string str)
    {
        return  new List<string>(str.Split(new char[] { '\n', '\r', ' ' }, StringSplitOptions.RemoveEmptyEntries));
    }

    public static LinkedList<String> makeLinkedList(String str)
    {
       return  new LinkedList<string>(str.Split(new char[] { '\n', '\r', ' ' }, StringSplitOptions.RemoveEmptyEntries));
    }

    public static void topTenWords(List<string> list)
    {
        Dictionary<string, int> wordDict = new Dictionary<string, int>();
        foreach (string word in list)
        {
            if (wordDict.ContainsKey(word))
            {
                wordDict[word]++;
            }
            else
            {
                wordDict.Add(word, 1);
            }
        }
        var sortedWordsByDescending = wordDict.OrderByDescending(pair => pair.Value).ToList();
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"word: \"{sortedWordsByDescending[i].Key}\", count: {sortedWordsByDescending[i].Value}");
        }
    }
    
    
    public static void Main(string[] args)
    {
        Console.WriteLine("Top ten words");
        String text = readText("D:\\temp\\input.txt");
        String cleanedText = removeAllPunctuations(text);
        List<string> textList = makeList(cleanedText);
        LinkedList<string> linkedStringList = makeLinkedList(cleanedText);
        topTenWords(textList);
        Console.WriteLine("=============================================");
        Console.WriteLine("Stopwatch test");
        stopWatchTest(textList, linkedStringList);
    }
}