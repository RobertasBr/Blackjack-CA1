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

        static int Wins = 0;
        static int Losses = 0;
        static int Ties = 0;
        
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
                        //Get dealer cards  //Replace with keep going until someone losses
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
                                //Compares your and dealer cards //Replace with keep going until someone losses
                                CompareCards();
                            }
                        }
                    }
                }

                ShowStatistics();

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
                //Win situation
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{playerNumber} is greater than {dealerNumber}");
                Console.ForegroundColor = ConsoleColor.White;
                Wins++;
                return true;
            }
            if (playerNumber < dealerNumber)
            {
                //Loss situation
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{playerNumber} is less than {dealerNumber}");
                Console.ForegroundColor = ConsoleColor.White;
                Losses++;
                return false;
            }
            else
            {
                //Tie situation
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{playerNumber} and {dealerNumber} are tied");
                Console.ForegroundColor = ConsoleColor.White;
                Ties++;
                return false;
            }
        }
        static int GetAnotherCard()
        {
            int hitCard = RandomCard();

            //Shows what cards got hit
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Hit card: {hitCard}\n");
            Console.ForegroundColor = ConsoleColor.White;

            return hitCard;
        }
        
        static void ShowStatistics()
        {
            Console.WriteLine($"\nYou currently have:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"    Wins: {Wins}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"    Losses: {Losses}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    Ties: {Ties}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}


//Add class for cards

//Add getting actuals cards

//Debugging 