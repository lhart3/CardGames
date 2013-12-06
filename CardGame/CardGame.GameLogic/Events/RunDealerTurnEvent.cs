using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.GameLogic.Commands;

namespace CardGame.GameLogic.Events
{
    public class RunComputerPlayerTurnEvent : EventBase
    {
        public override IEnumerable<Commands.ICommand> GenerateCommands(Game game)
        {
            var player = game.Players.Single(p => p.Id == PlayerId);
            var playerAi = (AIPlayer)player;

            yield return new RunComputerPlayerTurnCommand() { Player = playerAi };
            yield return new AdvanceTurnCommand() { AdvancesToNextRound = true };
        }
    }
}
