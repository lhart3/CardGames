using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardGame.GameLogic.Events;
using CardGame.GameLogic.Commands;

namespace CardGame.GameLogic.Test.Unit
{
    public class TestBlackJackGame
    {
        [TestClass]
        public class BlackjackTests
        {

            [TestMethod]
            public void TestMethod1()
            {
                var dealerPlayer = new BlackjackDealerPlayer();

                var computerPlayer1 = new AIPlayerGames();

                var computerPlayer2 = new AIPlayerGames();

                Player[] players = new Player[3];
                players[0] = computerPlayer1;
                players[1] = computerPlayer2;
                players[2] = dealerPlayer;

                Deck deck = new Deck();
                BlackjackDealer dealer = new BlackjackDealer();
                Blackjack blackjack = new Blackjack(players, deck, dealer);

                var eventProcessor = new EventProcessor();

                var newhandevent = new NewBlackJackHandEvent();

                var events = new List<IEvent>() { newhandevent };

                var commands = eventProcessor.ProcessEvents(events, blackjack, true);

                events.Add(new RunComputerPlayerTurnEvent() { PlayerId = dealerPlayer.Id });
                events.Add(new RunComputerPlayerTurnEvent() { PlayerId = computerPlayer2.Id });
                events.Add(new RunComputerPlayerTurnEvent() { PlayerId = computerPlayer1.Id });


            }
        }
    }
}
