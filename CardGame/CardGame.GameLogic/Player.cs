using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardGame.GameLogic
{
    public class Player : IEquatable<Player>
    {
        public Guid Id { get; private set; }
        public int Currency { get; set; }
        public List<Card> Hand { get; private set; }

        public int RequestedCardCount { get; set; }

        protected Player()
        {
        }

        public Player(Guid id)
        {
            Id = id;
            Hand = new List<Card>();
        }

        public bool Equals(Player other)
        {
            throw new NotImplementedException();
        }
    }
}