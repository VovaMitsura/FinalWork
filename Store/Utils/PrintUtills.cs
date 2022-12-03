namespace Store.Utils;

public class PrintUtils
{
    public static void PrintList<T>(List<T> listToPrint)
    {
        for (int i = 0; i < listToPrint.Count; i++)
        {
            Console.WriteLine($"\t{i + 1}.{listToPrint[i]}");
        }

        Console.WriteLine();
    }
}