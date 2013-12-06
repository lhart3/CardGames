using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace CardGame.GameLogic
{
    public class BlackjackDealerPlayer : AIPlayer
    {
        public DealerState state;
        public bool alive = true;
        private PlayerHand Dealerplayer;
        private int profitToLoss;
        private int score = 0;
        public BlackjackDealerPlayer()
        {

        }
        public override void Play(Game game)
        {
            var blackjackGame = (Blackjack)game;

            BlackJackDealerStartUp();

            foreach (PlayerHand dealerPlayer in game.Turn.Players)
            {
                if (dealerPlayer.GetType() == typeof(BlackjackDealerPlayer))
                {
                    Dealerplayer = dealerPlayer;
                }
            }
            DealerBlackJackFSM(blackjackGame);
        }
        public void BlackJackDealerStartUp()
        {
            alive = true;
            state = DealerState.Checking;
        }
        public void DealerBlackJackFSM(Blackjack game)
        {
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
                    case DealerState.EndHand:
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
            PlayerHand Hand = game.Turn.GetHandForPlayer(game.Turn.CurrentPlayer.Player);
            Int32 score = game.Turn.CurrentPlayer.Hand.Sum(c => game.GetValue(c, true));
            int score2 = 0;
            int totalPot = 0;
            if (!game.Bust(Hand))
            {
                if (game.ComputerStand(Hand))
                {
                   foreach (PlayerHand ph in game.Turn.Players)
                   {
                       if (ph.GetType() == typeof(BlackjackDealerPlayer))
                       {

                       }
                       else
                       {
                           score2 = ph.Hand.Sum(d => game.GetValue(d, true));
                           if (score - score2 > -1)
                           {
                               profitToLoss += ph.HighBid;
                               totalPot += ph.HighBid;
                           }
                           else
                           {
                               profitToLoss -= ph.HighBid;
                               totalPot += ph.HighBid;
                           }
                       }
                   }
                   if (profitToLoss < (-1 * (totalPot * .10)))
                   {
                       if (!game.ComputerSoftStand(Hand))
                       {
                           state = DealerState.Hit;
                       }
                       else
                       {
                           state = DealerState.EndHand;
                       }
                   }
                   else
                   {
                       state = DealerState.EndHand;
                   }
               }
               else
               {
                   state = DealerState.Hit;
               }
           }
           else
           {
               if (!game.ComputerSoftStand(Hand))
               {
                   state = DealerState.Hit;
               }
               else
               {
                   state = DealerState.EndHand;
               }
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
            foreach (PlayerHand dealerPlayer in game.Turn.Players)
            {
                if (dealerPlayer.GetType() == typeof(BlackjackDealerPlayer))
                {
                    Dealerplayer = dealerPlayer;
                    score = dealerPlayer.Hand.Sum(d => game.GetValue(d, false));
                }
            }
            foreach (PlayerHand player in game.Turn.Players)
            {
                if (player.GetType() == typeof(BlackjackDealerPlayer))
                {
                    
                }
                else
                {
                    if (game.TryCheckForWinner(player))
                    {
                        player.Player.Currency = player.HighBid * 2;
                        Dealerplayer.Player.Currency = Dealerplayer.Player.Currency - player.HighBid;
                    }
                    else
                    {
                        Dealerplayer.Player.Currency = Dealerplayer.Player.Currency + player.HighBid;
                    }
                }
            }
      }
}
    public enum DealerState
    {
        Checking,
        Hit,
        EndHand
    }
}