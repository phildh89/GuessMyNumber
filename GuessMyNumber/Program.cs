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

            if (input > 3 || input < 1)
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
            int temp = CompGuess / 2;

            while (input != CompGuess)
            {
                if (input > CompGuess)
                {
                    Console.WriteLine($"My guess is {CompGuess}, which is too low.");
                    CompGuess += temp;
                    if (temp != 1) temp /= 2;
                }
                else if (input < CompGuess)
                {
                    Console.WriteLine($"My guess is {CompGuess}, which is too high.");
                    CompGuess -= temp;
                    if (temp != 1) temp /= 2;
                }
            }
            Console.WriteLine($"{input} is the number!");


        }
        public static void UserGuess()
        {
            Console.Clear();
            Random Rand = new Random();
            int selectedNum = Rand.Next(1, 1001);
            Console.WriteLine("\n\tGuess the number between 1 and 1,000.");
            int input = Convert.ToInt32(Console.ReadLine());

            int count = 0;

            while (input != selectedNum)
            {
                if (input > selectedNum)
                {
                    Console.Write("\tYour guess is too high! Try again: ");
                    input = Convert.ToInt32(Console.ReadLine());
                    count++;
                }
                else if (input < selectedNum)
                {
                    Console.Write("\tYour guess is too low! Try again: ");
                    input = Convert.ToInt32(Console.ReadLine());
                    count++;
                }
            }
            Console.WriteLine($"\n\tYou have found the random number {selectedNum}! It took you {count} tries.");


        }
        public static void ComputerGuess()
        {
            Console.Clear();
            Console.Write("\n\tSelect a number between 1 and 100 for the computer to guess: ");
            int input = Convert.ToInt32(Console.ReadLine());

            while (input > 100 || input <1)
            {
                Console.Write("Invalid entry. Try Again: ");
                input = Convert.ToInt32(Console.ReadLine());
            }
            int CompGuess = 100 / 2;
            int temp = CompGuess / 2;
            int count = 1;

            while (input != CompGuess)
            {
                Console.WriteLine($"\tComputer guess the number: {CompGuess}");
                Console.WriteLine("\n\tSelect an option:");
                Console.WriteLine("\t\t1. Guess is too high");
                Console.WriteLine("\t\t2. Guess is too low");

                int userNavigation = Convert.ToInt32(Console.ReadLine());
                while (userNavigation != 1 && userNavigation != 2)
                {
                    Console.Write("Invalid input. Try again: ");
                    userNavigation = Convert.ToInt32(Console.ReadLine());
                }

                if (userNavigation == 2)
                {
                    CompGuess += temp;
                    if (temp != 1) temp /= 2;
                    count++;
                }
                else if (userNavigation == 1)
                {
                    CompGuess -= temp;
                    if (temp != 1) temp /= 2;
                    count++;
                }
            }
            Console.WriteLine($"\n\t\t{input} is the number! It took me {count} guesses.");

        }
    }
}
