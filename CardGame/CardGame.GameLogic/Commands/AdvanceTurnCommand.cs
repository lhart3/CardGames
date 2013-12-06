using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.GameLogic.Events;

namespace CardGame.GameLogic.Commands
{
    class AdvanceTurnCommand : ICommand
    {
        public bool AdvancesToNextRound { get; set; }

        public IEnumerable<IEvent> Process(Game game)
        {
            // advance to next player
            var startedNewRound = game.Turn.AdvanceToNextPlayer();

            // if we are back at the beginning, advance to next round
            if (startedNewRound && AdvancesToNextRound)
                game.Turn.RoundNumber++;

            return Enumerable.Empty<IEvent>();
        }
    }
}
