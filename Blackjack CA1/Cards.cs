using System;
using System.Collections.Generic;

namespace Blackjack_CA1
{
    class Deck
    {
        //Creates list of cards along with random number generator
        private List<Card> cards = new List<Card>();
        private Random random = new Random();

        //All the card suits and ranks available
        public Deck()
        {
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };


            //Generetes 52 cards in a deck
            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    cards.Add(new Card(rank, suit));
                }
            }
        }

        //Fisher-Yates shuffle algorithm
        public void Shuffle()
        {
            int cardCount = cards.Count;
            while (cardCount > 1)
            {
                cardCount--;
                int randomNumber = random.Next(cardCount + 1);
                Card value = cards[randomNumber];
                cards[randomNumber] = cards[cardCount];
                cards[cardCount] = value;
            }
        }

        //Draws the card and removes it from current deck
        public Card DrawCard()
        {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
    }
    //Card class with ranks and suits as strings
    class Card
    {
        public string Rank { get; }
        public string Suit { get; }

        public Card(string rank, string suit)
        {
            Rank = rank;
            Suit = suit;
        }

        //Gets values for A, K, Q, J
        public int GetValue()
        {
            if (Rank == "Ace")
                return 11;
            else if (Rank == "King" || Rank == "Queen" || Rank == "Jack")
                return 10;
            else
                return int.Parse(Rank);
        }

        //Allows hands to be displayed
        public override string ToString()
        {
            return Rank + " of " + Suit;
        }
    }

    //Player class used by player and dealer
    class Player
    {
        private List<Card> hand = new List<Card>();

        //Takes a card to player
        public void AddCard(Card card)
        {
            hand.Add(card);
        }

        //Formats hand to existing string
        public string GetHand()
        {
            return string.Join(", ", hand);
        }

        //Get dealer's first card thats visible
        public string GetUpCard()
        {
            return hand[0].ToString();
        }

        //Gets values to decide win/loss/tie
        public int GetScore()
        {
            int score = 0;
            int numberOfAces = 0;

            //Adds score of hand + checks for aces
            foreach (Card card in hand)
            {
                score += card.GetValue();
                if (card.Rank == "Ace")
                    numberOfAces++;
            }

            //Handle Ace value
            while (numberOfAces > 0 && score > 21)
            {
                score -= 10;
                numberOfAces--;
            }

            return score;
        }
    }
}
