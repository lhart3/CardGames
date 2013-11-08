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
     
        protected Player()
        {
        }

        public Player(Guid id)
        {
            Id = id;
        }

        public bool Equals(Player other)
        {
            throw new NotImplementedException();
        }
    }
}