using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardGame.Models
{
    public class Blackjack : Game
    {
        public Blackjack(Player[] players, Deck deck, BlackjackDealer dealer)
            : base(players, deck, dealer)
        {
        }

        private int GetValue(Card card, bool aceAsOne)
        {
            if (card.Number == 1)
            {
                if (aceAsOne)
                    return 1;
                else
                    return 11;
            }

            if (card.Number > 10)
                return 10;

            return card.Number;
        }

        public override bool TryCheckForWinner(out Player winner)
        {
            foreach (var player in Players)
            {
                var score = player.Hand.Sum(c => GetValue(c, true));

                if (score == 21)
                {
                    winner = player;
                    return true;
                }

                score = player.Hand.Sum(c => GetValue(c, false));

                if (score == 21)
                {
                    winner = player;
                    return true;
                }
            }

            winner = null;
            return false;
        }
    }
}