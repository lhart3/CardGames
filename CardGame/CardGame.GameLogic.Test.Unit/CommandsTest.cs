using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.GameLogic.Events;
using CardGame.GameLogic.Commands;

namespace CardGame.GameLogic.Test.Unit
{
    class CommandsTest
    {
        public void TestIt()
        {
            var eventProcessor = new EventProcessor();
            var commandProcessor = new CommandProcessor();

            var evt = new AdvanceTurnEvent() { AdvancesToNextRound = true };

            var commands = eventProcessor.Process(evt, null);

            commandProcessor.ProcessCommands(null, commands);
        }
    }
}
