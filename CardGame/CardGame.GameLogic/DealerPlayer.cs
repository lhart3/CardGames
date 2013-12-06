using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace CardGame.GameLogic
{
    public class DealerPlayer : AIPlayer
    {
        public DealerState state = DealerState.Init;
        public bool alive = true;
        private Deck deck;
        private IEnumerable<PlayerHand> players;
        public DealerPlayer()
        {

        }
        #region BlackJackFunctionsForDealer
        public override void BlackJack(Game game)
        {
            BlackJackStartUp();
            DealerBlackJackFSM(game);
        }
        public void BlackJackStartUp()
        {
            alive = true;
            state = DealerState.Init;
        }
        public void DealerBlackJackFSM(Game game)
        {
            while (alive)
            {
                switch (state)
                {
                    case DealerState.Init:
                        BlackJackInit(game);
                        break;
                    case DealerState.Setup:
                        BlackJackSetup(game);
                        break;
                    case DealerState.Deal:
                        BlackJackDeal(game);
                        break;
                    case DealerState.Checking:
                        BlackJackChecking(game);
                        break;
                    case DealerState.Hit:
                        BlackJackHit(game);
                        break;
                    case DealerState.EndGame:
                        BlackJackEndHand(game);
                        break;
                }
            }
        }
        public void BlackJackChangeAlive()
        {
            alive = !alive;
        }
        private void BlackJackInit(Game game)
        {
            game.Turn = new GameLogic.Turn(game.Players);
            game.Discard.Clear();
            state = DealerState.Setup;
        }
        private void BlackJackSetup(Game game)
        {
            deck = new Deck();
            players = game.Turn.Players;
            state = DealerState.Deal;
        }
        private void BlackJackDeal(Game game)
        {
            game.Dealer.DealStartingHand(deck, players);
            state = DealerState.Checking;
            BlackJackChangeAlive();
        }
        private void BlackJackChecking(Game game)
        {
            foreach(PlayerHand ph in players)
            {
                
            }
        }
        private void BlackJackHit(Game game)
        {
            game.Turn.CurrentPlayer.Hand.Add(game.Deck.Draw());
            state = DealerState.Checking;
        }
        private void BlackJackEndHand(Game game)
        {
            alive = false;
        }
        #endregion
 
        #region TexasHoldEmFunctionsForDealer
        public override void TexasHoldEm(Game game)
        {
            
        }
        #endregion

        #region FiveHandPokerFunctionsForDealer
        public override void FiveHandPoker(Game game)
        {

        }
        #endregion
    }
    public enum DealerState
    {
        Init,
        Setup,
        Deal,
        Checking,
        Hit,
        EndGame
    }
}