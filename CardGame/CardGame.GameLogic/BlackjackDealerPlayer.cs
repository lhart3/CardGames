using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace CardGame.GameLogic
{
    public class BlackjackDealerPlayer : AIPlayer
    {
        public DealerState state = DealerState.Checking;
        public bool alive = true;
        private Deck deck;
        private IEnumerable<PlayerHand> players;

        public BlackjackDealerPlayer()
        {
        }

        public override void Play(Game game)
        {
            var blackjackGame = (Blackjack)game;

            DealerBlackJackFSM(blackjackGame);
        }

        public void BlackJackStartUp()
        {
            alive = true;
            state = DealerState.Checking;
        }

        public void DealerBlackJackFSM(Blackjack game)
        {
            return;
            while (alive)
            {
                switch (state)
                {
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

        private void BlackJackChecking(Blackjack game)
        {
            foreach (PlayerHand ph in game.Turn.Players)
            {
                
            }
        }
        private void BlackJackHit(Blackjack game)
        {
            game.Dealer.DealForCurrentRound(game.Deck, game.Turn.CurrentPlayer, 1);
            state = DealerState.Checking;
        }
        private void BlackJackEndHand(Blackjack game)
        {
            alive = false;
        }
}
    public enum DealerState
    {
        Checking,
        Hit,
        EndGame
    }
}