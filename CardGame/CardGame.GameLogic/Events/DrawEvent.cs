using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.GameLogic.Events
{
    public class DrawEvent : EventBase
    {
        public override IEnumerable<Commands.ICommand> GenerateCommands(Game game)
        {
            yield break;
        }
    }
}
