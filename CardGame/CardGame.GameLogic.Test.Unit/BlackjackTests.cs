using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardGame.GameLogic.Events;
using CardGame.GameLogic.Commands;

namespace CardGame.GameLogic.Test.Unit
{
    [TestClass]
    public class BlackjackTests
    {

        [TestMethod]
        public void TestMethod1()
        {
            var dealerPlayer = new BlackjackDealerPlayer();
            Player[] players = new[] { new Player(Guid.NewGuid()), dealerPlayer };
            Deck deck = new Deck();
            BlackjackDealer dealer = new BlackjackDealer();
            Blackjack blackjack = new Blackjack(players, deck, dealer);

            var eventProcessor = new EventProcessor();

            var newhandevent = new NewBlackJackHandEvent();

            var events = new List<IEvent>() { newhandevent };

            var commands = eventProcessor.ProcessEvents(events, blackjack, true);

            // player clicks 'hit'
            events.Add(new DrawEvent() { PlayerId = blackjack.Turn.CurrentPlayer.Player.Id });
            commands = eventProcessor.ProcessEvents(events, blackjack, false);

            // player clicks 'stay'
            // advance to next turn, which causes the RunDealerTurnEvent to be processed
            events.Add(new AdvanceTurnEvent() { AdvancesToNextRound = true, PlayerId = blackjack.Turn.CurrentPlayer.Player.Id });
            commands = eventProcessor.ProcessEvents(events, blackjack, false);

            // player clicks 'stay' again
            // advance to next turn, which does nothing because there are no events left - how does the AI get to go again?
            events.Add(new AdvanceTurnEvent() { AdvancesToNextRound = true, PlayerId = blackjack.Turn.CurrentPlayer.Player.Id });
            commands = eventProcessor.ProcessEvents(events, blackjack, false);

            Assert.AreEqual(0, events.Count);
        }
    }
}
