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
    public class TurnTest
    {
        [TestMethod]
        public void AdvanceToNextPlayer_StartAtFirstPlayer_EndsOnSecondPlayer()
        {
            var players = new[] { new Player(Guid.NewGuid()), new Player(Guid.NewGuid()), new Player(Guid.NewGuid()) };
            var turn = new Turn(players);

            Assert.AreSame(players[0], turn.CurrentPlayer.Player);

            turn.AdvanceToNextPlayer();
            Assert.AreSame(players[1], turn.CurrentPlayer.Player);
        }

        [TestMethod]
        public void AdvanceToNextPlayer_StartAtLastPlayer_EndsOnFirstPlayer()
        {
            var players = new[] { new Player(Guid.NewGuid()), new Player(Guid.NewGuid()) };
            var turn = new Turn(players);

            turn.AdvanceToNextPlayer();
            Assert.AreSame(players[1], turn.CurrentPlayer.Player, "not able to start at last player");

            turn.AdvanceToNextPlayer();
            Assert.AreSame(players[0], turn.CurrentPlayer.Player);
        }
    }
}
