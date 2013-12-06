﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CardGame.GameLogic
{
    public class AIPlayerGames : AIPlayer
    {
        public AIState aiState;
        public bool hisTurn = false;

        #region BlackJackFunctionsForNonDealers
        public override void Play(Game game)
        {
            var blackjack = (Blackjack)game;
            AIPlayerBlackJackFSM(blackjack);
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
       private void BlackJackChecking(Blackjack game)
       {
           aiState = AIState.Pass;
           aiState = AIState.Hit;
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
    public enum AIState
    {
        Checking,
        Hit,
        Pass
    }
}

