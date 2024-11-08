class Tuerme
{
    static int Hanoi(int n, int counter, char x, char y, char z)
    {
        if (n == 1)
        {
            Console.WriteLine($"Bewege Scheibe 1 von {x} nach {z}");
            return counter;
        }

        Hanoi(n - 1,counter,  x, z, y);
        Console.WriteLine($"Bewege Scheibe {n} von {x} nach {z}");

        Hanoi(n - 1,counter, y, x, z);
        return 5;
    }

    public static void Main()
    {
        int n = 3, counter = 0;
        
        Console.WriteLine("Vorgehensweise zum Lösen: ");
        int m = Convert.ToInt32(Console.ReadLine());
        counter = Hanoi(m, counter, 'A', 'B', 'C');
        Console.WriteLine($"In {counter} Zügen.");
    }
}
