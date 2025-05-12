namespace Module10;

public interface ICalculator
{
    int Calculate(int x, int y);
}

public class Calculator : ICalculator
{
    public int Calculate(int x, int y)
    {
        return x + y;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Calculator calculator = new Calculator();
        Logger logger = new Logger();
        try
        {
            int a = Int32.Parse(Console.ReadLine());
            int b = Int32.Parse(Console.ReadLine());
            logger.LogInfo("Result = " + calculator.Calculate(a, b).ToString());
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
        }
        finally
        {
            logger.LogInfo("Result calculated successfully");

        }
    }
}