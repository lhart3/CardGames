using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.GameLogic.Commands;

namespace CardGame.GameLogic.Events
{
    public class EventProcessor
    {
        public IEnumerable<ICommand> ProcessEvents(List<IEvent> events, Game game, bool allEvents)
        {
            var commandProcessor = new CommandProcessor();
            var commandsExcecuted = new List<ICommand>();

            bool processedAnEvent;

            do
            {
                var commands = allEvents
                    ? ProcessAllEvents(events, game)
                    : ProcessEventsForCurrentPlayer(events, game);

                var generatedEvents = commandProcessor.ProcessCommands(game, commands);

                events.AddRange(generatedEvents);
                commandsExcecuted.AddRange(commands);

                processedAnEvent = commands.Any();
                allEvents = false;
            }
            while (processedAnEvent);

            return commandsExcecuted;
        }

        private IEnumerable<ICommand> ProcessEvents(IList<IEvent> events, Game game, Func<IEvent, bool> predicate)
        {
            List<ICommand> commands = new List<ICommand>();

            var eventsToProcess = events.ToArray();

            foreach (var evt in eventsToProcess.Where(predicate))
            {
                var generatedCommands = evt.GenerateCommands(game);
                commands.AddRange(generatedCommands);

                events.Remove(evt);
            }

            return commands;
        }

        private IEnumerable<ICommand> ProcessEventsForCurrentPlayer(IList<IEvent> events, Game game)
        {
            return ProcessEvents(events, game, e => e.PlayerId == game.Turn.CurrentPlayer.Player.Id);
        }

        private IEnumerable<ICommand> ProcessAllEvents(IList<IEvent> events, Game game)
        {
            return ProcessEvents(events, game, e => true);
        }
    }
}
