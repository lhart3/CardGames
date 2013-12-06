using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.GameLogic.Events;

namespace CardGame.GameLogic.Commands
{
    public interface ICommand
    {
        IEnumerable<IEvent> Process(Game game);
    }
}
