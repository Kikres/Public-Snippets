namespace Public_Snippets.Tools;

internal static class TerminalHelper
{
    public static void ClearAndPrintMessage(string message)
    {
        Console.Clear();
        Console.WriteLine(message);
    }

    public static void DelayMessage(string message)
    {
        ClearAndPrintMessage(message);
        Thread.Sleep(2000);
        Console.Clear();
    }

    public static string? ReadInput(string? message)
    {
        if (message != null)
        {
            ClearAndPrintMessage(message);
        }
        return Console.ReadLine();
    }

    public static bool InputValidation(string? message)
    {
        string msg;
        if (message != null)
        {
            msg = $"{message} (Y)es (N)o";
        }
        else
        {
            msg = "Are you sure? (Y)es (N)o";
        }
        ClearAndPrintMessage(msg);

        while (true)
        {
            var input = Console.ReadKey(true);
            switch (input.Key)
            {
                case ConsoleKey.Y:
                    Console.CursorVisible = true;
                    return true;

                case ConsoleKey.N:
                    Console.CursorVisible = true;
                    return false;
            }
        }
    }

    public static void Header(string row1)
    {
        Console.WriteLine("##############################");
        Console.WriteLine(row1);
        Console.WriteLine("##############################");
        Console.WriteLine();
    }

    public static void Title(string row1, string row2)
    {
        Console.Write(row1);
        // Adjustment
        Console.CursorLeft = 24;
        Console.WriteLine(row2);
        Console.WriteLine("------------------------------");
    }

    public static void ProgressBar(int current, int target)
    {
        var toPrint = "";
        var procentage = (int)(((decimal)current / (decimal)target) * 100);
        switch (procentage)
        {
            case int i when i >= 0 && i < 10:
                toPrint = "[----------]";
                break;

            case int i when i >= 0 && i < 10:
                toPrint = "[#---------]";
                break;

            case int i when i >= 10 && i < 20:
                toPrint = "[##--------]";
                break;

            case int i when i >= 20 && i < 30:
                toPrint = "[###-------]";
                break;

            case int i when i >= 30 && i < 40:
                toPrint = "[####------]";
                break;

            case int i when i >= 40 && i < 50:
                toPrint = "[#####-----]";
                break;

            case int i when i >= 50 && i < 60:
                toPrint = "[######----]";
                break;

            case int i when i >= 60 && i < 70:
                toPrint = "[#######---]";
                break;

            case int i when i >= 70 && i < 80:
                toPrint = "[########--]";
                break;

            case int i when i >= 80 && i < 90:
                toPrint = "[#########-]";
                break;

            case int i when i >= 90 && i <= 100:
                toPrint = "[##########]";
                break;
        }

        Console.Write(toPrint);
    }
}