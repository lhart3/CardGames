using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.GameLogic.Commands;

namespace CardGame.GameLogic.Events
{
    public interface IEvent
    {
        IEnumerable<ICommand> GenerateCommands(Game game);
    }
}
