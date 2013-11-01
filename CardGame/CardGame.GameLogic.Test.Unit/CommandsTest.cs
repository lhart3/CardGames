using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.GameLogic.Events;
using CardGame.GameLogic.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardGame.GameLogic.Test.Unit
{
    [TestClass]
    public class CommandsTest
    {
        [TestMethod]
        public void TestIt()
        {
            //var eventProcessor = new EventProcessor();
            //var commandProcessor = new CommandProcessor();

            //var evt = new AdvanceTurnEvent() { AdvancesToNextRound = true };

            //var commands = eventProcessor.Process(evt, null);

            //commandProcessor.ProcessCommands(null, commands);

            var players = new[] { new Player(Guid.NewGuid()), new Player(Guid.NewGuid()), new Player(Guid.NewGuid()) };
            var turn = new Turn(players);

            Assert.AreSame(players[0], turn.CurrentPlayer);

            turn.AdvanceToNextPlayer();
            Assert.AreSame(players[1], turn.CurrentPlayer);

            turn.AdvanceToNextPlayer();
            Assert.AreSame(players[2], turn.CurrentPlayer);

            turn.AdvanceToNextPlayer();
            Assert.AreSame(players[0], turn.CurrentPlayer);
        }
    }
}
