using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.GameLogic.Commands;
using CardGame.GameLogic.Commands.Turn;

namespace CardGame.GameLogic.Events
{
    public class AdvanceTurnEvent : IEvent
    {
        public bool AdvancesToNextRound { get; set; }

        public IEnumerable<ICommand> GenerateCommands(Game game)
        {
            yield return new AdvanceTurnCommand() { AdvancesToNextRound = AdvancesToNextRound };
        }
    }
}
