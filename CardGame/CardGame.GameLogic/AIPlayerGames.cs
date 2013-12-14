using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using CardGame.GameLogic.Events;
using CardGame.GameLogic.Commands;
using CardGame;

namespace CardGame.GameLogic
{
    #region AIPlayerGamesBlackJack
    public class AIPlayerGames : AIPlayer
    {
        public AIState aiState;
        public bool hisTurn = false;

        #region BlackJackFunctionsForNonDealers
        public override void Play(Game game)
        {
            var blackjack = (Blackjack)game;
            blackjack.game = (Blackjack)game;
            AIPlayerBlackJackFSM(blackjack);
            var evt = new RaiseBidEvent(game.Turn.CurrentPlayer.Player.Id, 100);
            var eventProcessor = new EventProcessor();
            var commandProcessor = new CommandProcessor();
            blackjack._events.Add(evt);

            eventProcessor.ProcessEvents(blackjack._events, game, true);

        }
        public void AIPlayerBlackJackFSM(Blackjack game)
        {
            while (hisTurn)
            {
                switch (aiState)
                {
                    case AIState.Checking:
                        BlackJackChecking(game);
                        break;
                    case AIState.Hit:
                        BlackJackHit(game);
                        break;
                    case AIState.Pass:
                        BlackJackPass(game);
                        break;
                }
            }
        }
        public void BlackJackChangeHisTurn()
        {
            hisTurn = !hisTurn;
        }
        public void BlackJackAIrStartUp()
        {
            hisTurn = true;
            aiState = AIState.Checking;
        }
        private void BlackJackChecking(Blackjack game)
        {
            game.ResetCounter();
            PlayerHand PlayerHand = game.Turn.GetHandForPlayer(game.Turn.CurrentPlayer.Player);
            Int32 aces = PlayerHand.Hand.Count(d => d.Number == CardType.Ace);
            Int32 score = game.Turn.CurrentPlayer.Hand.Sum(c => game.GetValue(c, false, aces));
            if (score > 21)
            {
                game.ResetCounter();
                score = game.Turn.CurrentPlayer.Hand.Sum(c => game.GetValue(c, true, aces));
            }
            if (!game.Bust(PlayerHand))
                if (game.ComputerStand(PlayerHand))
                {
                    if (score > 19)
                    {
                        if (game.DoublingDown(PlayerHand))
                        {
                            aiState = AIState.Pass;
                        }
                        else
                        {
                            aiState = AIState.Pass;
                        }
                    }
                    else if (score == 19)
                    {
                        aiState = AIState.Pass;
                    }
                    else
                    {
                        if (!game.ComputerSoftStand(PlayerHand))
                        {
                            aiState = AIState.Hit;
                        }
                        else
                        {
                            aiState = AIState.Pass;
                        }
                    }
                }
                else
                {
                    aiState = AIState.Hit;
                }
            else
            {
                if (!game.ComputerSoftStand(PlayerHand))
                {
                    aiState = AIState.Hit;
                }
                else
                {
                    aiState = AIState.Pass;
                }
            }
        }
        private void BlackJackHit(Blackjack game)
        {
            game.Turn.CurrentPlayer.Hand.Add(game.Deck.Draw());
            aiState = AIState.Checking;
        }
        private void BlackJackPass(Blackjack game)
        {
            BlackJackChangeHisTurn();
            game.Turn.AdvanceToNextPlayer();
            if (game.Turn.CurrentPlayer.GetType() == typeof(AIPlayerGames))
            {
                BlackJackChangeHisTurn();
                aiState = AIState.Checking;
            }
            else if (game.Turn.CurrentPlayer.GetType() == typeof(BlackjackDealerPlayer))
            {
                BlackjackDealerPlayer dp = new BlackjackDealerPlayer();
                BlackJackChangeHisTurn();
                dp.BlackJackChangeAlive();
                dp.DealerBlackJackFSM(game);
            }
            else
            {
                return;
            }
        }
        #endregion

    }
    #endregion



    public enum AIState
    {
        Checking,
        Hit,
        Pass
    }
}


