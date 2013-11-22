using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardGame.GameLogic
{
    public class Blackjack : Game
    {
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
        public override bool TryCheckForWinner(PlayerHand playerHand, out Player winner)
        {
            foreach (var player in Turn.Players)
            {
                var score = player.Hand.Sum(c => GetValue(c, true));
                if (score == 12)
                {
                      winner = player.Player;
                      return true;
                }
            }
            winner = null;
            return false;
        }
        public bool Bust(PlayerHand playerHand, out BlackJackHandValue value)
        {
            var score = playerHand.Hand.Sum(c => GetValue(c, false));
            if (score > 21)
            {
                score = playerHand.Hand.Sum(c => GetValue(c, true));
                if (score > 21)
                {
                    value = new BlackJackHandValue() { HandScore = -1 };
                    return true;
                }
            }
            value = null;
            return false;
        }
        public bool ComputerStand(PlayerHand dealerHand, out BlackJackHandValue value)
        {
            var score = dealerHand.Hand.Sum(c => GetValue(c, false));

            if (score > 16)
            {
                value = new BlackJackHandValue() { HandScore = score };
                return true;
            }

            value = null;
            return false;
        }
        public bool ComputerSoftStand(PlayerHand dealerhand, out BlackJackHandValue value)
        {
            var score = dealerhand.Hand.Sum(c => GetValue(c, true));

            if (score < 16)
            {
                value = new BlackJackHandValue() { HandScore = score };
                return true;
            }

            value = null;
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
        //Information came from the website www.blackjackinfo.com/blackjack-rules.php
        public BlackJackHandValue GetBlackJackHandValue(PlayerHand playerHand)
        {
            BlackJackHandValue value;
            if (!Bust(playerHand, out value))
            {
                return value;
            }
            return null;
        }
    }

}