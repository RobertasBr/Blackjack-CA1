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
        //Global variables
        static int randomCard = 0;
        static int playerNumber;
        static int dealerNumber;
        static int card;
        static string spacing = new string('-', 35);

        //Random declared here to have a different seed everytime
        static Random random = new Random();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(spacing);
                //Get your cards
                GetFirstNumbers();

                //Asks for user input
                Console.Write($"Do you want to hit or stand? (h/s): ");
                string action = Console.ReadLine();

                Console.WriteLine(spacing);

                if (action == "h")
                {
                    int hitCard = GetAnotherCard();

                    playerNumber += hitCard;

                    if (playerNumber > 21)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{playerNumber}, You bust");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        //Get dealer cards
                        GetSecondNumbers();

                        if (action == "h")
                        {
                            int dealerHit = GetAnotherCard();
                            Console.WriteLine($"Dealer hit {dealerHit}");

                            dealerNumber += dealerHit;

                            if (dealerNumber > 21)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"{dealerNumber}, Dealer bust");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                //Compares your and dealer cards
                                CompareCards();
                            }
                        }
                    }
                }

                //Allows user to stop loop
                Console.WriteLine($"{spacing}\nWould you like to go again? (y/n): ");

                string goAgain = Console.ReadLine();

                if (goAgain != "y")
                {
                    break;
                }
            }
        }

        static int GetFirstNumbers()
        {
            GetRandomCards();

            Console.WriteLine($"You got: {randomCard}");

            playerNumber = randomCard;

            return playerNumber;
        }

        static int GetSecondNumbers()
        {
            GetRandomCards();

            Console.WriteLine($"Dealer got: {randomCard}");

            dealerNumber = randomCard;

            return dealerNumber;
        }

        static int GetRandomCards()
        {
            int cardOne = RandomCard();
            int cardTwo = RandomCard();

            randomCard = cardOne + cardTwo;

            return randomCard;
        }

        static int RandomCard()
        {
            card = random.Next(1, 10);
            
            Console.ForegroundColor = ConsoleColor.DarkGray;
            //Console.WriteLine($"RandomCard: {card}");
            Console.ForegroundColor= ConsoleColor.White;
            
            return card;
        }
        

        static bool CompareCards()
        {

            if (playerNumber > dealerNumber)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{playerNumber} is greater than {dealerNumber}");
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
            if (playerNumber < dealerNumber)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{playerNumber} is less than {dealerNumber}");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{playerNumber} and {dealerNumber} are equal");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
        }
        static int GetAnotherCard()
        {
            int hitCard = RandomCard();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Hit card: {hitCard}\n");
            Console.ForegroundColor = ConsoleColor.White;

            return hitCard;
        }
    }
}


//Add class for cards

//Comment

//Add getting actuals cards

//>21 Exception Loss

//Add win/loss stats

//Debugging 