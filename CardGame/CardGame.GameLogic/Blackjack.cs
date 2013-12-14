using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CardGame.GameLogic.Events;
using CardGame.GameLogic.Commands;
using CardGame;

namespace CardGame.GameLogic
{
    public class Blackjack : Game
    {
        public PlayerHand DealerPlayer
        {
            get
            {
                var dealer = Players.First(p => p is BlackjackDealerPlayer);
                return Turn.Players.First(p => p.Player == dealer);
            }
        }
        public PlayerHand Player
        {
            get
            {
                var player = Players.First(p => p is Player);
                return Turn.Players.First(p => p.Player == player);
            }
        }
        public List<IEvent> _events;
        private int score;
        private PlayerHand Dealerplayer;
        private bool doubleDown = true;
        int counter = 1;
        public List<Player> WinnerList = new List<Player>();
        public List<Player> Loserlist = new List<Player>();
        public Game game;
        public Blackjack(Player[] players, Deck deck, BlackjackDealer dealer)
            : base(players, deck, dealer)
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
        public int Comparison(int player, int dealer)
        {
            if (player > 21)
            {
                return -1;
            }
            else if (player < 22 && dealer > 21)
            {
                return 1;
            }
            else
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
        }
        public override bool TryCheckForWinner(PlayerHand player)
        {
            int score2;
            int aces = 0;
            int aces2 = 0;
            foreach (PlayerHand dealerPlayer in Turn.Players)
            {
                if (dealerPlayer.Player.GetType() == typeof(BlackjackDealerPlayer))
                {
                    Dealerplayer = dealerPlayer;
                    aces = Dealerplayer.Hand.Count(d => d.Number == CardType.Ace);
                    score = Dealerplayer.Hand.Sum(d => GetValue(d, false, aces));
                    if (score > 21)
                    {
                        score = Dealerplayer.Hand.Sum(d => GetValue(d, true, aces));
                    }
                }
            }
            aces2 = player.Hand.Count(d => d.Number == CardType.Ace);
            score2 = player.Hand.Sum(d => GetValue(d, false, aces2));
            if (score2 > 21)
            {
                score2 = player.Hand.Sum(d => GetValue(d, true, aces2));
            }
            if (Comparison(score2, score) == 1)
            {
                WinnerList.Add(player.Player);
                Loserlist.Add(Dealerplayer.Player);
                return true;
            }
            else
            {
                WinnerList.Add(Dealerplayer.Player);
                Loserlist.Add(player.Player);
                return false;
            }
        }
        public bool Bust(PlayerHand playerHand)
        {
            Int32 aces = playerHand.Hand.Count(d => d.Number == CardType.Ace);
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
            Int32 aces = dealerHand.Hand.Count(d => d.Number == CardType.Ace);
            Int32 score = dealerHand.Hand.Sum(c => GetValue(c, false, aces));
            if (score > 16)
            {
                return true;
            }
            return false;
        }
        public bool ComputerSoftStand(PlayerHand dealerHand)
        {
            Int32 aces = dealerHand.Hand.Count(d => d.Number == CardType.Ace);
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
            Int32 aces = playerhand.Hand.Count(d => d.Number == CardType.Ace);
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
            if (playerhand.Hand.Count() == 2 && doubleDown == true)
            {
                var evt = new RaiseBidEvent(playerhand.Player.Id, playerhand.HighBid);
                var eventProcessor = new EventProcessor();
                var commandProcessor = new CommandProcessor();
                _events.Add(evt);
                eventProcessor.ProcessEvents(_events, game, true);
                doubleDown = false;
                return true;
            }
            doubleDown = false;
            return false;
        }
    }
}