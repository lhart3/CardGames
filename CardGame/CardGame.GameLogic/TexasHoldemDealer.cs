using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.GameLogic
{
    class TexasHoldemDealer : DealerForGameWithFixedStartingHandSize
    {
        Game _game;
        public TexasHoldemDealer(Game game)
        {
            _game = game;
        }

        public override int StartingHandSize { get { return 2; } }

        public override void DealForCurrentRound(Deck deck, PlayerHand player, int count)
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
        }
    }
}
