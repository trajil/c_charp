class Tuerme
{
    static void AutoSolveHanoi(int n,ref int counter, char x, char y, char z)
    {
        if (n == 1)
        {
            counter++;
            Console.WriteLine($"Bewege Scheibe 1 von {x} nach {z}");
            return;
        }

        AutoSolveHanoi(n - 1,ref counter, x, z, y);
        Console.WriteLine($"Bewege Scheibe {n} von {x} nach {z}");

        counter++;
        AutoSolveHanoi(n - 1,ref counter, y, x, z);

    }

    public static void Main()
    {

        int n = 3, counter = 0;

        Console.WriteLine("Vorgehensweise zum Lösen: ");
        // int m = Convert.ToInt32(Console.ReadLine());
        AutoSolveHanoi(n,ref counter, 'A', 'B', 'C');
        Console.WriteLine($"In {counter} Zügen.");
    }
}
