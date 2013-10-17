using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardGame.Models
{
    public class Player
    {
        public int Currency { get; set; }
        public List<Card> Hand { get; private set; }

        public Player()
        {
            Hand = new List<Card>();
        }
    }
}