using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.GameLogic.Commands
{
    class NewHandCommand : ICommand
    {
        public virtual void Process(Game game)
        {
            game.Deck.Populate();
            game.Deck.Shuffle();
            game.Discard.Clear();

            game.Turn = new GameLogic.Turn(game.Players);
        }
    }
}
