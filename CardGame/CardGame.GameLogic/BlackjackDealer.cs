using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardGame.GameLogic
{
    public class BlackjackDealer : DealerForGameWithFixedStartingHandSize
    {
        public override void DealForCurrentRound(Deck deck, Player player)
        {
            if (player.RequestedCardCount > 0)
                player.Hand.Add(deck.Draw());
        }

        public override int StartingHandSize { get { return 2; } }
    }
}