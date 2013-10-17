using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardGame.Models
{
    public class Deck
    {
        private Queue<Card> Cards { get; set; }

        public void Shuffle()
        {
        }

        public Card Draw()
        {
            var card = Cards.Dequeue();

            return card;
        }
    }
}