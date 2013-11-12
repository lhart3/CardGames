using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.GameLogic.Commands
{
    class NewDeckCommand : ICommand
    {
        public virtual void Process(Game game)
        {
            game.Deck.Populate();
            game.Deck.Shuffle();
        }
    }
}
