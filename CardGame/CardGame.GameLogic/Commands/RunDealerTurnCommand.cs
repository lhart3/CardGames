using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.GameLogic.Events;

namespace CardGame.GameLogic.Commands
{
    class RunComputerPlayerTurnCommand : ICommand
    {
        public AIPlayer Player { get; set; }

        public IEnumerable<IEvent> Process(Game game)
        {
            Player.Play(game);

            yield return new RunComputerPlayerTurnEvent() { PlayerId = Player.Id };
        }
    }
}
