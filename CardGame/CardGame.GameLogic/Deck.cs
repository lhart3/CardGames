using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardGame.GameLogic
{
    public class Deck
    {
        protected Queue<Card> Cards { get; set; }

        public Deck()
        {
            Cards = new Queue<Card>();

            Populate();
            Shuffle();
        }

        public void Populate()
        {
            for (int i = 1; i < 14; i++)
            {
                foreach (var suit in suits.all)
                {
                    Card card = new Card(suit, i);
                    Cards.Enqueue(card);
                }
            }
        }

        public void Shuffle()
        {
            List<Card> list = new List<Card>(Cards);
            Cards = new Queue<Card>();

            var random= new Random();
            while (list.Count > 0)
            {
                Int32 index = random.Next(list.Count);
                Card card = list[index];
                list.RemoveAt(index);
                Cards.Enqueue(card);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The Next Card From the Deck; If there is no cards return null</returns>
        public Card Draw()
        {
            if (Cards.Count == 0)
            {
                return null;
            }
            else
            {
                Card card = Cards.Dequeue();

                return card;
            }
        }
    }
}