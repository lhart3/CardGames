using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.GameLogic
{
    class DummyPlayer : Player
    {
    }

    class TexasHoldemDealer : DealerForGameWithFixedStartingHandSize
    {
        Game _game;
        public TexasHoldemDealer(Game game)
        {
            _game = game;
        }

        public override int StartingHandSize { get { return 2; } }

        public override void DealForCurrentRound(Deck deck, Player player)
        {
            int cardsToDeal = 0;
            if (_game.currentRound == 1)
            {
                cardsToDeal = 3;
            }
            else
            {
                cardsToDeal = 1;
            }

            if (player is DummyPlayer)
            {
                for (int i = 0; i < cardsToDeal; ++i)
                    player.Hand.Add(deck.Draw());
            }
        }
    }
}
