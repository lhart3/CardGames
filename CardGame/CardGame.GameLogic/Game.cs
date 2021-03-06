﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardGame.GameLogic
{
    public abstract class Game
    {
        public IEnumerable<Player> Players { get; private set; }
        public Deck Deck { get; set; }

        public Turn Turn { get; set; }

        public Dealer Dealer { get; private set; }

        public List<Card> Discard { get; private set; }

        public List<Card> DummyHand { get; private set; }

        public bool IsGameOver { get; set; }

        public bool IsDealersTurn { get; set; }

        public int currentRound;

        public Game(Player[] players, Deck deck, Dealer dealer)
        {
            Players = players;
            Deck = deck;
            Discard = new List<Card>();
            Dealer = dealer;

            Turn = new Turn(players);
        }

        public abstract bool TryCheckForWinner(PlayerHand player);

        public void AddPlayer(Player player)
        {
            var list = new List<Player>(Players);
            list.Add(player);

            Players = list;
        }


        
    }
}