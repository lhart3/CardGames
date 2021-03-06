﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using CardGame.GameLogic;

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
            Currency = 50000;
        }
        public override void Play(Game game)
        {
            var blackjackGame = (Blackjack)game;

            BlackJackDealerStartUp();

            foreach (PlayerHand dealerPlayer in game.Turn.Players)
            {
                if (dealerPlayer.Player.GetType() == typeof(BlackjackDealerPlayer))
                {
                    Dealerplayer = dealerPlayer;
                }
            }
            DealerBlackJackFSM(blackjackGame);

            game.IsDealersTurn = true;
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
            game.ResetCounter();
            PlayerHand PlayerHand = game.Turn.GetHandForPlayer(game.Turn.CurrentPlayer.Player);
            Int32 aces = PlayerHand.Hand.Count(d => d.Number == CardType.Ace);
            Int32 score = game.Turn.CurrentPlayer.Hand.Sum(c => game.GetValue(c, false, aces));
            if (score > 21)
            {
                game.ResetCounter();
                score = game.Turn.CurrentPlayer.Hand.Sum(c => game.GetValue(c, true, aces));
            }
            Int32 aces2 = 0;
            int score2 = 0;
            int totalPot = 0;
            if (!game.Bust(PlayerHand))
            {
                if (game.ComputerStand(PlayerHand))
                {
                   foreach (PlayerHand ph in game.Turn.Players)
                   {
                       if (ph.Player.GetType() == typeof(BlackjackDealerPlayer))
                       {

                       }
                       else
                       {
                           game.ResetCounter();
                           aces2 = PlayerHand.Hand.Count(d => d.Number == CardType.Ace);
                           score2 = ph.Hand.Sum(d => game.GetValue(d, false, aces2));
                           if (score2 > 21)
                           {
                               game.ResetCounter();
                               score2 = ph.Hand.Sum(d => game.GetValue(d, true, aces2));
                           }
                           if (score.CompareTo(score2) == 1)
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
                       if (!game.ComputerSoftStand(PlayerHand))
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
               if (!game.ComputerSoftStand(PlayerHand))
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
            int aces;

            foreach (PlayerHand dealerPlayer in game.Turn.Players)
            {
                if (dealerPlayer.Player.GetType() == typeof(BlackjackDealerPlayer))
                {
                    Dealerplayer = dealerPlayer;
                    game.ResetCounter();
                    aces = Dealerplayer.Hand.Count(d => d.Number == CardType.Ace);
                    score = Dealerplayer.Hand.Sum(d => game.GetValue(d, false, aces));
                    if (score > 21)
                    {
                        game.ResetCounter();
                        score = Dealerplayer.Hand.Sum(d => game.GetValue(d, true, aces));
                    }
                }
            }
            foreach (PlayerHand playerhand in game.Turn.Players)
            {
                if (playerhand.Player.GetType() == typeof(BlackjackDealerPlayer))
                {
                    
                }
                else
                {
                    
                    if (game.TryCheckForWinner(playerhand))
                    {
                        playerhand.Player.Currency = playerhand.HighBid * 2;
                        Dealerplayer.Player.Currency = Dealerplayer.Player.Currency - playerhand.HighBid;
                    }
                    else
                    {
                        Dealerplayer.Player.Currency = Dealerplayer.Player.Currency + playerhand.HighBid;
                    }
                }
            }
            game.IsGameOver = true;
            PrintWinners pw = new PrintWinners(game);
      }
}
    public enum DealerState
    {
        Checking,
        Hit,
        EndHand
    }
}