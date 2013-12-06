using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.GameLogic
{
    public class BlackJackHandValue : IComparable<BlackJackHandValue>
    {
        public int HandScore;
        public List<int> SplittingPairs;
        public int CompareTo(int player, int dealer)
        {
            Int32 result = player - dealer;
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
