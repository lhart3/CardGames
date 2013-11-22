using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.GameLogic
{
    class HandValue : IComparable<HandValue>
    {
        public int Rank;
        public List<int> Ordered_Values;

        public int CompareTo(HandValue other)
        {
            var result = this.Rank - other.Rank;
            if (result != 0)
            {
                return result;
            }
            else
            {
                for(int i = 0; i < Ordered_Values.Count; i++)
                {
                    result = this.Ordered_Values[i] - other.Ordered_Values[i];
                    if (result != 0)
                    {
                        return result;
                    }
                }
            }
            return 0;
        }
    }
}
