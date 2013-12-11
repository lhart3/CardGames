using System;
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
        int counter = 1;
        public Blackjack(Player[] players, Deck deck, BlackjackDealer dealer) : base(players, deck, dealer)
        {

        }
        public void ResetCounter()
        {
            counter = 1;
            doubleDown = true;
        }
        public int GetValue(Card card, bool aceAsOne, int IndexNumber)
        {
            if (card.Number == CardType.Ace)
            {
                
                  if (IndexNumber == counter && !aceAsOne)
                  {
                       return 11;
                  }
                  else if (IndexNumber == counter && aceAsOne)
                  {
                       return 1;
                  }
                  else
                  {
                       counter++;
                       return 1;
                  }
            }
            if ((int)card.Number > 10)
            {
                return 10;
            }
            else
            {
                return (int)card.Number;
            }
        }
        public int CheckNumberOfAces(Card card)
        {
            int number = 0;
            if (card.Number == CardType.Ace)
            {
                number++;
            }
            return number;
        }
        public int Comparison(int player, int dealer)
        {
            int result = player - dealer;
            if (result < 1)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
        public override Player TryCheckForWinner(PlayerHand player, out Player winner)
        {
            int score2;
            int aces = 0;
            int aces2 = 0;
            foreach (PlayerHand dealerPlayer in Turn.Players)
            {
                if (dealerPlayer.GetType() == typeof(BlackjackDealerPlayer))
                {
                    Dealerplayer = dealerPlayer;
                    aces = Dealerplayer.Hand.Sum(d => CheckNumberOfAces(d));
                    score = Dealerplayer.Hand.Sum(d => GetValue(d, false, aces));
                    if (score > 21)
                    {
                        score = Dealerplayer.Hand.Sum(d => GetValue(d, true, aces));
                    }
                }
            }
            aces2 = player.Hand.Sum(d => CheckNumberOfAces(d));
            score2 = player.Hand.Sum(d => GetValue(d, false, aces2));
            if (score2 > 21)
            {
                score2 = player.Hand.Sum(d => GetValue(d, true, aces2));
            }
            if (Comparison(score2, score) == 1)
            {
                winner = player.Player;
                return winner;
            }
            else
            {
                winner = Dealerplayer.Player;
                return winner;
            }
        }
        public bool Bust(PlayerHand playerHand)
        {
            Int32 aces = playerHand.Hand.Sum(d => CheckNumberOfAces(d));
            Int32 score = playerHand.Hand.Sum(c => GetValue(c, false, aces));
            if (score > 21)
            {
                score = playerHand.Hand.Sum(c => GetValue(c, true, aces));
                if (score > 21)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public bool ComputerStand(PlayerHand dealerHand)
        {
            Int32 aces = dealerHand.Hand.Sum(d => CheckNumberOfAces(d));
            Int32 score = dealerHand.Hand.Sum(c => GetValue(c, false, aces));
            if (score > 16)
            {
                return true;
            }
            return false;
        }
        public bool ComputerSoftStand(PlayerHand dealerHand)
        {
            Int32 aces = dealerHand.Hand.Sum(d => CheckNumberOfAces(d));
            Int32 score = dealerHand.Hand.Sum(c => GetValue(c, true, aces));
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
            Int32 aces = playerhand.Hand.Sum(d => CheckNumberOfAces(d));
            Int32 score = playerhand.Hand.Sum(c => GetValue(c, true, aces));
            int splitpairs = score / 2;
            if (splittingPairs.Count < playerhand.Hand.Count)
            {
                return true;
            }
            return false;
        }
        public bool DoublingDown(PlayerHand playerhand)
        {
            if (playerhand.Hand.Count() == 2 && doubleDown == false)
            {
                playerhand.HighBid = playerhand.HighBid * 2;
                doubleDown = true;
                return true;
            }
            doubleDown = false;
            return false;
        }
    }
}