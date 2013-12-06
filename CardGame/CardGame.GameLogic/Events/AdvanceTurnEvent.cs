using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.GameLogic.Commands;

namespace CardGame.GameLogic.Events
{
    public class AdvanceTurnEvent : EventBase
    {
        public bool AdvancesToNextRound { get; set; }

        public override IEnumerable<ICommand> GenerateCommands(Game game)
        {
            yield return new AdvanceTurnCommand() { AdvancesToNextRound = AdvancesToNextRound };
        }
    }
}
