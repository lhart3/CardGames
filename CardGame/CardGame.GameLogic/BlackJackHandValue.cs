using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.GameLogic
{
    class BlackJackHandValue : IComparable<BlackJackHandValue>
    {
        public int HandScore;
        public List<int> SplittingPairs;
        public int CompareTo(BlackJackHandValue dealer)
        {
            var result = this.HandScore - dealer.HandScore;
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
}
