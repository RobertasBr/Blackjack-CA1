using System;

namespace Blackjack_CA1
{
    internal class Program
    {
        //Global variables
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
                PlayGame();
                Console.WriteLine(spacing);

                ShowStatistics();

                Console.Write("Do you want to play again? (y/n): ");
                if (Console.ReadLine().ToLower() == "n")
                    break;
            }
        }

        static void PlayGame()
        {
            //Shuffles deck on game start
            Deck deck = new Deck();
            deck.Shuffle();

            //Creates a player and dealer class
            Player player = new Player();
            Player dealer = new Player();

            //Fairly gives cards out in alternating order
            player.AddCard(deck.DrawCard());
            dealer.AddCard(deck.DrawCard());
            player.AddCard(deck.DrawCard());
            dealer.AddCard(deck.DrawCard());

            //Displays your hand and dealer up card
            Console.WriteLine("Your cards: " + player.GetHand());

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Dealer's card: " + dealer.GetUpCard());
            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                //Asks for user input
                Console.Write("Do you want to hit or stand? (h/s): ");
                string input = Console.ReadLine().ToLower();

                if (input == "h")
                {
                    //Draws and displays card
                    player.AddCard(deck.DrawCard());
                    Console.WriteLine("Your cards: " + player.GetHand());

                    //Early bust check
                    if (player.GetScore() > 21)
                    {
                        Console.WriteLine("Bust! You lose.");
                        Losses++;
                        return;
                    }
                }
                else if (input == "s")
                {
                    break;
                }
            }

            //Makes the dealer 'decide' to hit or stand 
            while (dealer.GetScore() < 17)
            {
                dealer.AddCard(deck.DrawCard());
            }

            Console.WriteLine("Your cards: " + player.GetHand());

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Dealer's cards: " + dealer.GetHand());
            Console.ForegroundColor = ConsoleColor.White;

            //Determine the winner
            int playerScore = player.GetScore();
            int dealerScore = dealer.GetScore();

            //Win/Loss/Tie conditions
            if (playerScore > 21)
            {
                Console.WriteLine("Bust! You lose.");
                Losses++;
            }
            else if (dealerScore > 21 || playerScore > dealerScore)
            {
                Console.WriteLine("You win!");
                Wins++;
            }
            else if (dealerScore > playerScore)
            {
                Console.WriteLine("You lose.");
                Losses++;
            }
            else
            {
                Console.WriteLine("It's a tie!");
                Ties++;
            }
        }

        //Additional Feature: Show Statitics
        //Keeps a tally of wins/losses/ties and displays after every match
        public static void ShowStatistics()
        {
            Console.WriteLine($"\nYou currently have:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"    Wins: {Wins}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"    Losses: {Losses}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    Ties: {Ties}\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(spacing);
        }
    }
}