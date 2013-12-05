using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CardGame.GameLogic
{
    public class AIPlayerGames : AIPlayer
    {
        public AIState aiState;
        public bool hisTurn = true;
        public override void BlackJack(Game game)
        {
            AIPlayerFSM(game);
        }
        public void AIPlayerFSM(Game game)
        {
            while (hisTurn)
            {
               switch (aiState)
               {
                  case AIState.Checking:
                       BlackJackChecking(game);
                      break;
                  case AIState.Hit:
                      Hit(game);
                      break;
                  case AIState.Pass:
                      BlackJackPass(game);
                      break;
                    }
                }
            }
       private void BlackJackChecking(Game game)
       {
           aiState = AIState.Pass;
           aiState = AIState.Hit;
        }
        private void Hit(Game game)
        {
            game.Turn.CurrentPlayer.Hand.Add(game.Deck.Draw());
            aiState = AIState.Checking;
        }
        private void BlackJackPass(Game game)
        {
            game.Turn.AdvanceToNextPlayer();
            aiState = AIState.Checking;
        }
        public override void TexasHoldEm(Game game)
        {
            throw new NotImplementedException();
        }

        public override void FiveHandPoker(Game game)
        {
            throw new NotImplementedException();
        }
    }
    public enum AIState
    {
        Checking,
        Hit,
        Pass
    }
}

