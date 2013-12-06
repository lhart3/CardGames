using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.GameLogic.Commands;
using CardGame.GameLogic.Events;

namespace CardGame.GameLogic.Commands
{
    public class CommandProcessor
    {
        private List<ICommand> _allCommandsEver = new List<ICommand>();

        public IEnumerable<IEvent> ProcessCommands(Game game, IEnumerable<ICommand> commands)
        {
            var newEvents = new List<IEvent>();

            foreach (var command in commands)
            {
                var generatedEvents = command.Process(game);
                newEvents.AddRange(generatedEvents);
            }

            // 'log' the commands
            _allCommandsEver.AddRange(commands);

            return newEvents;
        }
    }
}
