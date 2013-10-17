using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardGame.Models
{
    public enum Suit
    {
        Hearts,
        Clubs,
        Spades,
        Diamonds
    }

    public class Card
    {
        public Suit Suit { get; private set; }

        public int Number { get; private set; }

        public Card(Suit suit, int number)
        {
            Suit = suit;
            Number = number;
        }

        public Card(int number)
        {
            Number = number;
        }
    }
}