using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.GameLogic.Commands;

namespace CardGame.GameLogic.Events
{
    public class NewHandEvent : EventBase
    {
        public override IEnumerable<Commands.ICommand> GenerateCommands(Game game)
        {
            yield return new NewBlackJackHandCommand();
        }
    }
}
