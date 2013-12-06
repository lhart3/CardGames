using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.GameLogic.Events;

namespace CardGame.GameLogic.Commands
{
    public class FoldCommand : ICommand
    {
        public PlayerHand Player { get; set; }

        public IEnumerable<IEvent> Process(Game game)
        {
            game.Turn.RemoveFromHand(Player);
            game.Discard.AddRange(Player.Hand);
            Player.Hand.Clear();

            return Enumerable.Empty<IEvent>();
        }
    }
}
