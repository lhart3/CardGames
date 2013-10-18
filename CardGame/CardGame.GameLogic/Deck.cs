using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardGame.GameLogic
{
    public class Deck
    {
        private Queue<Card> Cards { get; set; }

        public Deck()
        {
            Populate();
            Shuffle();
        }

        private void Populate()
        {

            for (int i = 1; i < 14; i++)
            {
                foreach (var suit in suits.all)
                {
                    var card = new Card(suit, i);
                    Cards.Enqueue(card);
                }
            }
        }

        public void Shuffle()
        {
            var list = new List<Card>(Cards);
            Cards = new Queue<Card>();

            var random= new Random();
            while (list.Count > 0)
            {
                var index = random.Next(list.Count);
                var card = list[index];
                list.RemoveAt(index);
                Cards.Enqueue(card);
            }
        }

        public Card Draw()
        {
            var card = Cards.Dequeue();

            return card;
        }
    }
}