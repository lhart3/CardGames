using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.GameLogic.Commands;

namespace CardGame.GameLogic.Events
{
    public class FoldEvent : IEvent
    {
        Guid PlayerId { get; set; }
        public IEnumerable<Commands.ICommand> GenerateCommands(Game game)
        {
            var player = game.Players.FirstOrDefault(p => p.Id == PlayerId);

            if (player != null)
                yield return new FoldCommand() { Player = player };
        }
    }
}
