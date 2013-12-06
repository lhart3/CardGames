﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardGame.GameLogic
{
    public class Blackjack : Game
    {
        private int score;
        private PlayerHand Dealerplayer;
        private bool doubleDown = true;
        public Blackjack(Player[] players, Deck deck, BlackjackDealer dealer) : base(players, deck, dealer)
        {

        }

        public int GetValue(Card card, bool aceAsOne)
        {
            if (card.Number == CardType.Ace)
            {
                if (aceAsOne)
                    return 1;
                else
                    return 11;
            }

            if ((int)card.Number > 10)
                return 10;

            return (int)card.Number;
        }
        public override bool TryCheckForWinner(PlayerHand player)
        {
            int score2;
            foreach (PlayerHand dealerPlayer in Turn.Players)
            {
                if (dealerPlayer.GetType() == typeof(BlackjackDealerPlayer))
                {
                    Dealerplayer = dealerPlayer;
                    score = dealerPlayer.Hand.Sum(d => GetValue(d, false));
                }
            }
            score2 = player.Hand.Sum(d => GetValue(d, false));
            if (score.CompareTo(score2) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Bust(PlayerHand playerHand)
        {
            Int32 score = playerHand.Hand.Sum(c => GetValue(c, true));
            if (score > 21)
            {
                return true;
            }
            return false;
        }
        public bool ComputerStand(PlayerHand dealerHand)
        {
            Int32 score = dealerHand.Hand.Sum(c => GetValue(c, false));

            if (score > 16)
            {
                return true;
            }
            return false;
        }
        public bool ComputerSoftStand(PlayerHand dealerhand)
        {
            Int32 score = dealerhand.Hand.Sum(c => GetValue(c, true));

            if (score > 16)
            {
                return true;
            }
            return false;
        }
        public bool SplittingPairsHand(PlayerHand playerhand)
        {
            var SplittingPairs = playerhand.Hand.Select(c => (int)c.Number).OrderByDescending(v => v);
            HashSet<int> splittingPairs = new HashSet<int>(SplittingPairs);
            var score = playerhand.Hand.Sum(c => GetValue(c, true));
            int splitpairs = score / 2;

            if (splittingPairs.Count < playerhand.Hand.Count)
            {
                return true;
            }
            return false;
        }
        public bool DoublingDown(PlayerHand playerhand)
        {
            if (playerhand.Hand.Count() == 2)
            {
                playerhand.HighBid = playerhand.HighBid * 2;
                return true;
            }
            return false;
        }
        public void ToggleDoubleDown()
        {
            doubleDown = !doubleDown;

        }
        //Information came from the website www.blackjackinfo.com/blackjack-rules.php
    }

}