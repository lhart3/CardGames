using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.GameLogic.Commands;

namespace CardGame.GameLogic.Events
{
    public class EventProcessor
    {
        public IEnumerable<ICommand> Process(IEvent evt, Game game)
        {
            var commands = evt.GenerateCommands(game);

            return commands;
        }
    }
}
