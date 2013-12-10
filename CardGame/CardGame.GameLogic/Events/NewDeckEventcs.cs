using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.GameLogic.Commands;

namespace CardGame.GameLogic.Events
{
    class NewDeckEvent : IEvent
    {
        public Guid PlayerId { get; set; }

        public IEnumerable<Commands.ICommand> GenerateCommands(Game game)
        {
            yield return new NewDeckCommand();
        }
    }
}
