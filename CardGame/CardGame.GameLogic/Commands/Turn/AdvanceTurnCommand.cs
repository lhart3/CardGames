using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.GameLogic.Commands.Turn
{
    class AdvanceTurnCommand : ICommand
    {
        public bool AdvancesToNextRound { get; set; }

        public void Process(Game game)
        {
            // advance to next player
            var startedNewRound = game.Turn.AdvanceToNextPlayer();

            // if we are back at the beginning, advance to next round
            if (startedNewRound && AdvancesToNextRound)
                game.Turn.RoundNumber++;
        }
    }
}
