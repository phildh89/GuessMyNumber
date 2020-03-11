using System;

namespace GuessMyNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            PickOptions();

        }
        public static void PickOptions()
        {
            Console.WriteLine("\n\tEnter a number to choose your game:");
            Console.WriteLine("\n\t\t1. Let the computer find your number between 1 and 10");
            Console.WriteLine("\n\t\t2. Try to find the number between 1 and 1,000");
            Console.WriteLine("\n\t\t3. You guide the computer to find your number between 1 and 100");

            int input = Convert.ToInt32(Console.ReadLine());

            if (input > 3 || input <1)
            {
                Console.WriteLine("Invalid entry. Choose a number between 1 and 3.");
                PickOptions();
            }
            else if (input == 1)
            {
                BisectionAlg();
            }
            else if (input == 2)
            {
                UserGuess();
            }
            else if (input == 3)
            {
                ComputerGuess();
            }

        }
        public static void BisectionAlg()
        {
            Console.Clear();
            int[] numArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.Write("\n\tEnter a number between 1 and 10: ");
            int input = Convert.ToInt32(Console.ReadLine());
            while (input > 10 || input < 1)
            {
                Console.Write("\tInvalid entry. Enter a number between 1 and 10: ");
                input = Convert.ToInt32(Console.ReadLine());
            }

            int CompGuess = numArr.Length / 2;
            

            for (int i = 0; input != CompGuess; i++)        // 1 2 3 4 5 6 7 8 9 10
            {
                if (input > CompGuess)
                {
                    Console.WriteLine($"My guess is {CompGuess}, which is too low.");
                    CompGuess += CompGuess/2;
                    continue;
                }
                else if (input < CompGuess)
                {
                    Console.WriteLine($"My guess is {CompGuess}, which is too high.");
                    CompGuess -= CompGuess/2;
                    continue;
                }
            }
            Console.WriteLine($"{input} is the number!");


        }
        public static void UserGuess()
        {

        }
        public static void ComputerGuess()
        {

        }
    }
}
