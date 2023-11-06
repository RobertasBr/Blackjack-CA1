using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Blackjack_CA1
{
    internal class Program
    {
        static int randomCard = 0;
        static int firstNumber;
        static int secondNumber;

        static Random random = new Random();
        static void Main(string[] args)
        {
            while (true)
            {
            GetFirstNumbers();
            GetSecondNumbers();
            CompareTwo();
            }
        }

        static int GetFirstNumbers()
        {
            GetRandomCards();

            Console.WriteLine($"First numbers are {randomCard}\n");

            firstNumber = randomCard;

            return firstNumber;
        }

        static int GetSecondNumbers()
        {
            GetRandomCards();

            Console.WriteLine($"Second numbers are {randomCard}\n");

            secondNumber = randomCard;

            return secondNumber;
        }

        static int GetRandomCards()
        {
            int cardOne = random.Next(1, 10);
            Console.WriteLine(cardOne);
            int cardTwo = random.Next(1, 10);
            Console.WriteLine(cardTwo);

            randomCard = cardOne + cardTwo; 

            return randomCard;
        }

        static bool CompareTwo()
        {

            if (firstNumber > secondNumber)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{firstNumber} is greater than {secondNumber}");
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{firstNumber} is less than {secondNumber}");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
        }
    }
}
