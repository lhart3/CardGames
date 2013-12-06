using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.GameLogic.Events;

namespace CardGame.GameLogic.Commands
{
    class NewDeckCommand : ICommand
    {
        public virtual IEnumerable<IEvent> Process(Game game)
        {
            game.Deck.Populate();
            game.Deck.Shuffle();

            return Enumerable.Empty<IEvent>();
        }
    }
}
