using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.GameLogic.Events;

namespace CardGame.GameLogic.Commands
{
    class NewBlackJackHandCommand : ICommand
    {
        public virtual IEnumerable<IEvent> Process(Game game)
        {
            game.Turn = new Turn(game.Players);

            game.Discard.Clear();
            game.Deck = new Deck();

            game.Dealer.DealStartingHand(game.Deck, game.Turn.Players);

            return Enumerable.Empty<IEvent>();
        }
    }
}
