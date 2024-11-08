class Tuerme
{
    static void AutoSolveHanoi(int n, ref int counter, char x, char y, char z)
    {
        if (n == 1)
        {
            counter++;
            Console.WriteLine($"Moving disk 1 from {x} to {z}");
            return;
        }

        AutoSolveHanoi(n - 1, ref counter, x, z, y);
        Console.WriteLine($"Moving disk {n} from {x} to {z}");

        counter++;
        AutoSolveHanoi(n - 1, ref counter, y, x, z);

    }
    static void ChooseMethod()
    {

    }
    static int SetAmountOfDisks(int n)
    {
        int diskLimiter = 8;
        bool correctAmountOfDisks = false;

        do
        {
            Console.WriteLine($"Please enter the number of disks to be used (between 1 and {diskLimiter}): ");

            // forcing integer input from user
            bool notAnInt = true;
            string input = "";
            while (notAnInt)
            {
                input = Console.ReadLine();
                try
                {
                    n = Convert.ToInt32(input);
                    notAnInt = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            }

            if (n >= 1 && n <= diskLimiter)
                correctAmountOfDisks = true;
            else if (n < 1)
            {
                Console.WriteLine("You entered too few disks, it must be over 1");

            }
            else
            {
                Console.WriteLine($"You entered too many disks, it must be under {diskLimiter + 1}");
            }
        } while (!correctAmountOfDisks);

        return n;
    }

    public static bool AskPlayerForReplay(bool playerWantsToContinue)
    {

        Console.Write("Do you want to continue? (Y/N): ");
        char input = Console.ReadKey().KeyChar;

        if (input == 'Y' || input == 'y')
        {
            Console.WriteLine("\nYou chose to continue.");
            return playerWantsToContinue = true;
        }
        else if (input == 'N' || input == 'n')
        {
            Console.WriteLine("\nYou chose to exit.");
            return playerWantsToContinue = false;
        }
        else
        {
            Console.WriteLine("\nInvalid choice.");
            return playerWantsToContinue = false;
        }
    }
    public static void Main()
    {
        bool playerWantsToContinue = false;

        do
        {
            int n = 1, counter = 0;

            n = SetAmountOfDisks(n);
            Console.WriteLine("Path to completing the towers: ");
            AutoSolveHanoi(n, ref counter, 'A', 'B', 'C');
            Console.WriteLine($"Amout of turns needed: {counter}");
            playerWantsToContinue = AskPlayerForReplay(playerWantsToContinue);
        } while (playerWantsToContinue);
    }
}