using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardGame.GameLogic
{
    public enum Suit
    {
        Hearts,
        Clubs,
        Spades,
        Diamonds
    }

    public enum CardType
    {
        Two = 2,
        Ace = 14
    }

    public static class suits
    {
        public static IEnumerable<Suit> all { get { return new[] { Suit.Hearts, Suit.Clubs, Suit.Spades, Suit.Diamonds }; } }
    }


    public class Card
    {
        public Suit Suit { get; private set; }

        public CardType Number { get; private set; }

        public Card(Suit suit, int number)
        {
            Suit = suit;
            Number = (CardType)number;
        }

        public Card(int number)
        {
            Number = (CardType)number;
        }
    }
}