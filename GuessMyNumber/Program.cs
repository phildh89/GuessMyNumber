using System;
using System.Collections.Generic;

namespace GuessMyNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            PickOptions();

        }
        static int[] StartingArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        static int count = 1;


        public static void PickOptions()
        {
            Console.WriteLine("\n\tEnter a number to choose your game:");
            Console.WriteLine("\n\t\t1. Let the computer find your number between 1 and 10");
            Console.WriteLine("\n\t\t2. Try to find the number between 1 and 1,000");
            Console.WriteLine("\n\t\t3. You guide the computer to find your number between 1 and 100");

            try
            {
                int input = Convert.ToInt32(Console.ReadLine());

                while (input > 3 || input < 1)
                {
                    Console.WriteLine("Invalid entry. Choose a number between 1 and 3.");
                    input = Convert.ToInt32(Console.ReadLine());
                }

                if (input == 1)
                {
                    Console.Clear();
                    Console.Write("\n\tEnter a number between 1 and 10: ");
                    int userNum = Convert.ToInt32(Console.ReadLine());
                    while (userNum > 10 || userNum < 1)
                    {
                        Console.Write("\tInvalid entry. Enter a number between 1 and 10: ");
                        userNum = Convert.ToInt32(Console.ReadLine());
                    }
                    BisectionAlg(StartingArr, userNum);
                }
                else if (input == 2)
                {
                    UserGuess();
                }
                else if (input == 3)
                {
                    Console.Clear();
                    Console.Write("\n\tSelect a number between 1 and 100 for the computer to guess: ");
                    int userNum = Convert.ToInt32(Console.ReadLine());
                    while (userNum > 100 || userNum < 1)
                    {
                        Console.Write("Invalid entry. Try Again: ");
                        userNum = Convert.ToInt32(Console.ReadLine());
                    }

                    //create array for 100 nums
                    int[] CompGuessArr = new int[100];
                    for (int i = 1; i < 101; i++)
                    {
                        CompGuessArr[i - 1] = i;
                    }
                    ComputerGuess(CompGuessArr, userNum);
                }
        }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Invalid entry. Try again.");
                PickOptions();
    }
}
        public static int ArrAverage(int[] numArr)
        {
            int arrSum = 0;
            foreach (var i in numArr)
            {
                arrSum += i;
            }
            return arrSum/numArr.Length;
        }
        public static void PrintArr(int[] numArr)
        {
            Console.Write("{ ");

            foreach (var i in numArr)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine("}");

        }
        public static int FindIndex(int arrElement ,int[] numArr)
        {
            for (int i = 0; i < numArr.Length; i++)
            {
                if (numArr[i] == arrElement)
                {
                    return i;
                }
            }
            return -1;//Place holder to return error.
        }
        public static void BisectionAlg(int[] numArr,int input)
        {

            PrintArr(numArr);
            int compGuess = ArrAverage(numArr);
            int[] tempArr = new int[input > compGuess ? numArr.Length - FindIndex(compGuess,numArr) -1: FindIndex(compGuess, numArr)];
            
            if (input > compGuess)
            {
                Console.WriteLine($"My guess is {compGuess}, which is too low.\n");
                int arrIndex = FindIndex(compGuess,numArr);
                for (int i = 0; i < tempArr.Length; i++)
                {
                    tempArr[i] = numArr[arrIndex+1];
                    arrIndex++;
                }
                BisectionAlg(tempArr,input); //recursion

            }
            else if (input < compGuess)   
            {
                Console.WriteLine($"My guess is {compGuess}, which is too high.\n");
                int arrIndex = FindIndex(compGuess, numArr);
                for (int i = 0; i < arrIndex; i++)
                {
                    tempArr[i] = numArr[i];
                }
                BisectionAlg(tempArr, input); //recursion
            }
            
            Console.WriteLine($"{input} is the number!");
            Console.WriteLine("\nPress Enter to Continue");
            Console.ReadKey();
            PickOptions();

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
        public static void ComputerGuess(int[] numArr, int input)
        {
            PrintArr(numArr);

            int compGuess = ArrAverage(numArr);
            int[] tempArr = new int[input > compGuess ? numArr.Length - FindIndex(compGuess, numArr) - 1 : FindIndex(compGuess, numArr)];

            if (input == compGuess)
            {
                Console.WriteLine($"\n\t\t{input} is the number! It took me {count} guesses.");
                Console.WriteLine("\nPress Enter to Continue");
                Console.ReadKey();
                PickOptions();
            }
            Console.WriteLine($"\tComputer guess the number: {compGuess}");
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
                int arrIndex = FindIndex(compGuess, numArr);
                for (int i = 0; i < tempArr.Length; i++)
                {
                    tempArr[i] = numArr[arrIndex + 1];
                    arrIndex++;
                }
                count++;
                ComputerGuess(tempArr, input);
            }
            else if (userNavigation == 1)
            {
                int arrIndex = FindIndex(compGuess, numArr);
                for (int i = 0; i < arrIndex; i++)
                {
                    tempArr[i] = numArr[i];
                }
                count++;
                ComputerGuess(tempArr, input);

            }

        }
    }
}
