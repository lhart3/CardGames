using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardGame.Models
{
    public abstract class Game
    {
        public Player[] Players { get; private set; }
        public Deck Deck { get; private set; }

        public Dealer Dealer { get; private set; }

        public Game(Player[] players, Deck deck, Dealer dealer)
        {
            Players = players;
            Deck = deck;
            Dealer = dealer;
        }

        public abstract bool TryCheckForWinner(out Player winner);
    }
}