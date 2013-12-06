using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.GameLogic.Commands;

namespace CardGame.GameLogic.Events
{
    public class FoldEvent : EventBase
    {
        public override IEnumerable<Commands.ICommand> GenerateCommands(Game game)
        {
            var player = game.Players.FirstOrDefault(p => p.Id == PlayerId);

            if (player != null)
            {
                var playerHand = game.Turn.GetHandForPlayer(player);
                yield return new FoldCommand() { Player = playerHand };
                yield return new AdvanceTurnCommand() { AdvancesToNextRound = true };
            }
        }
    }
}
