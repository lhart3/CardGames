using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardGame.Models
{
    public class BlackjackDealer : Dealer
    {
        public override void Deal(Deck deck, int count, Player player)
        {
            for (int i = 0; i < count; ++i)
            {
                var card = deck.Draw();
                player.Hand.Add(card);
            }
        }
    }
}