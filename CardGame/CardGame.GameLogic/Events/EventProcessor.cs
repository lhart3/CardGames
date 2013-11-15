using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.GameLogic.Commands;

namespace CardGame.GameLogic.Events
{
    public class EventProcessor
    {
        public IEnumerable<ICommand> Process(ICollection<IEvent> events, Game game)
        {
            var currentPlayerId = game.Turn.CurrentPlayer.Player.Id;

            var eventsToProcess = events.ToArray();
            List<ICommand> commands = new List<ICommand>();

            foreach (var evt in eventsToProcess.Where(e => e.PlayerId == currentPlayerId))
            {
                var generatedCommands = evt.GenerateCommands(game);
                commands.AddRange(generatedCommands);

                events.Remove(evt);
            }

            return commands;
        }
    }
}
