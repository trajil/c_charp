﻿class Tuerme
{
    public static char[,] map = { { 'o', 'i' }, { 'o', 'i' }, { 'o', 'i' } };
    public static char blank = ' ', pillar = '|', floor = '=';

    static void GenerateMap(int size)
    {
        // 5 times 3 is the minimal size for the map
        int rowLength = 5 + 6 * size;
        int colLength = 3 + size;
    }
    static void FillMap()
    {
        
    }
    static void RenderMap()
    {
        int rowLength = map.GetLength(0);
        int colLength = map.GetLength(1);

        for (int i = 0; i < rowLength; i++)
        {
            for (int j = 0; j < colLength; j++)
            {
                Console.Write(string.Format("{0} ", map[i, j]));
            }
            Console.Write(Environment.NewLine + Environment.NewLine);
        }
    }


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
    static int ChooseGameType(int gameType)
    {
        Console.WriteLine("Do you want to play the game (1) or see it getting autosolved (2)?");
        string input = "";
        bool notAnInt = true, intNotInRange = true;

        // forcing valid integer input from user
        while (notAnInt || intNotInRange)
        {
            input = Console.ReadLine();
            try
            {
                // gameType = Convert.ToInt32(input);
                bool successfullyParsed = int.TryParse(input, out gameType);
                if (gameType >= 1 && gameType <= 2)
                {
                    intNotInRange = false;
                }
                notAnInt = false;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter an integer.");
                continue;
            }
            if (intNotInRange)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer (1 or 2).");
            }
        }
        return gameType;
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
                    bool successfullyParsed = int.TryParse(input, out n);

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
            int n = 1, counter = 0, gameType = 1;
            n = SetAmountOfDisks(n);
            gameType = ChooseGameType(gameType);

            // path: Playing
            if (gameType == 1)
            {

            }

            // path: Autosolving
            else if (gameType == 2)
            {
                Console.WriteLine("Path to completing the towers: ");
                AutoSolveHanoi(n, ref counter, 'A', 'B', 'C');
                Console.WriteLine($"Amout of turns needed: {counter}");
            }
            //GenerateMap(n);
            //FillMap();
            RenderMap();
            playerWantsToContinue = AskPlayerForReplay(playerWantsToContinue);
        } while (playerWantsToContinue);
    }
}