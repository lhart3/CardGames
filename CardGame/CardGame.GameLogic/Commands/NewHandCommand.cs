using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.GameLogic.Turn;

namespace CardGame.GameLogic.Commands
{
    class NewHandCommand : ICommand
    {
        public virtual void Process(Game game)
        {
            game.Deck.Populate();
            game.Deck.Shuffle();
            game.Discard.Clear();
            game.Turn.Pot = 0;
            game.Turn.RoundNumber = 1;
            game.Turn._currentPlayerNode = game.Turn._turnOrder.First;
        }
    }
}
