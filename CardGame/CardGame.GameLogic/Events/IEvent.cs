using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.GameLogic.Commands;

namespace CardGame.GameLogic.Events
{
    public interface IEvent
    {
        Guid PlayerId { get; }
        IEnumerable<ICommand> GenerateCommands(Game game);
    }

    public abstract class EventBase : IEvent
    {
        public Guid PlayerId { get; set; }

        public abstract IEnumerable<ICommand> GenerateCommands(Game game);
    }
}
