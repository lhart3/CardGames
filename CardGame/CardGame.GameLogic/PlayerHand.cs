using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.GameLogic
{
    public class PlayerHand
    {
        public List<Card> Hand { get; private set; }
        public Player Player { get; set; }
        public int HighBid { get; set; }

        public PlayerHand(Player player)
        {
            Hand = new List<Card>();
            Player = player;
        }
    }
}
