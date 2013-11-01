using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardGame.GameLogic
{
    public abstract class Game
    {
        public IEnumerable<Player> Players { get; private set; }
        public Deck Deck { get; private set; }

        public Turn Turn { get; private set; }

        public Dealer Dealer { get; private set; }
        public int currentRound;

        public Game(Player[] players, Deck deck, Dealer dealer)
        {
            Players = players;
            Deck = deck;
            Dealer = dealer;
        }

        public abstract bool TryCheckForWinner(out Player winner);

        public void AddPlayer(Player player)
        {
            var list = new List<Player>(Players);
            list.Add(player);

            Players = list;
        }
    }
}