using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardGame.GameLogic
{
    public abstract class Dealer
    {
        public abstract void DealStartingHand(Deck deck, IEnumerable<PlayerHand> players);

        public abstract void DealForCurrentRound(Deck deck, PlayerHand player, int count);
    }

    public abstract class DealerForGameWithFixedStartingHandSize : Dealer
    {
        public abstract int StartingHandSize { get; }

        public override void DealStartingHand(Deck deck, IEnumerable<PlayerHand> players)
        {
            for (int i = 0; i < StartingHandSize; i++)
            {
                foreach (var player in players)
                {
                    var card = deck.Draw();
                    player.Hand.Add(card);
                }
            }
        }
    }
}