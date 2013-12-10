using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.GameLogic.Commands;

namespace CardGame.GameLogic.Events
{
    class DoublingDownEvent : IEvent
    {
        public Guid PlayerId { get; set; }

        public IEnumerable<Commands.ICommand> GenerateCommands(Game game)
        {
            yield return new DoublingDownCommand();
        }
    }
}
