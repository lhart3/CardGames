using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.GameLogic
{
    class Poker
    {
        public Poker()
        {

        }
        public HandValue GetHandValue(PlayerHand hand)
        {
            HandValue value;
            if (StraightFlush(hand, out value))
            {
                return value;
            }
            else if (FourofaKind(hand, out value))
            {
                return value;
            }
            else if (FullHouse(hand, out value))
            {
                return value;
            }
            else if (Flush(hand, out value))
            {
                return value;
            }
            else if (Straight(hand, out value))
            {
                return value;
            }
            else if (ThreeofaKind(hand, out value))
            {
                return value;
            }
            else if (TwoPair(hand, out value))
            {
                return value;
            }
            else if (Onepair(hand, out value))
            {
                return value;
            }
            else
            {
                return value;
            }
        }

        public bool StraightFlush(PlayerHand playerhand, out HandValue value)
        {
            var cardNumericValues = playerhand.Hand.Select(c => (int)c.Number).OrderByDescending(v => v);

            if (Straight(playerhand, out value) && Flush(playerhand, out value))
            {
                value.Rank = 8;
                return true;
            }

            value = null;
            return false;
        }
        public bool FourofaKind(PlayerHand playerhand, out HandValue value)
        {
            var cardNumericValues = playerhand.Hand.Select(c => (int)c.Number).OrderByDescending(v => v);
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            foreach (int c in cardNumericValues)
            {
                if (!dictionary.ContainsValue(c))
                {
                    dictionary[c] = 1;
                }
                else
                {
                    dictionary[c] = dictionary[c] + 1;
                }
            }
            if (dictionary.Values.Any(v => v == 4))
            {
                value = new HandValue() { Rank = 7, Ordered_Values = cardNumericValues.ToList() };
                return true;
            }
            value = null;
            return false;
        }
        public bool FullHouse(PlayerHand playerhand, out HandValue value)
        {
            var cardNumericValues = playerhand.Hand.Select(c => (int)c.Number).OrderByDescending(v => v);
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            foreach (int c in cardNumericValues)
            {
                if (!dictionary.ContainsValue(c))
                {
                    dictionary[c] = 1;
                }
                else
                {
                    dictionary[c] = dictionary[c] + 1;
                }
            }
            if (dictionary.Values.Any(v => v == 3) && dictionary.Values.Any(v => v == 2))
            {
                value = new HandValue() { Rank = 6, Ordered_Values = cardNumericValues.ToList() };
                return true;
            }
            value = null;
            return false;

            // create new Dictionary<int, int>
            // foreach card
            //    if cardValue is not in dictionary
            //      dictionary[cardValue] = 1
            //    else
            //      increment value in dictionary

            // full house:
            // dictionary.Values.Any(v => v == 3) and dictionary.Values.Any(v => v == 2)

            // two pair
            // dictionary.Values.Count(v => v == 2) == 2

        }
        public bool Flush(PlayerHand playerhand, out HandValue value)
        {
            Int32 suitCount = playerhand.Hand.Select(c => c.Suit).Distinct().Count();
            if (suitCount == 1)
            {
                var cardNumericValues = playerhand.Hand.Select(c => (int)c.Number).OrderByDescending(v => v);
                value = new HandValue() { Rank = 5, Ordered_Values = cardNumericValues.ToList() };
                return true;
            }
            value = null;
            return false;
        }
        public bool Straight(PlayerHand playerhand, out HandValue value)
        {
            var cardNumericValues = playerhand.Hand.Select(c => (int)c.Number).OrderByDescending(v => v);
            if (cardNumericValues.First() - cardNumericValues.Last() == cardNumericValues.Count() - 1 && cardNumericValues.Distinct().Count() == cardNumericValues.Count())
            {
                value = new HandValue() { Rank = 4, Ordered_Values = cardNumericValues.ToList() };
                return true;
            }
            value = null;
            return false; 
        }
        public bool ThreeofaKind(PlayerHand playerhand, out HandValue value)
        {
            var cardNumericValues = playerhand.Hand.Select(c => (int)c.Number).OrderByDescending(v => v);
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            foreach (int c in cardNumericValues)
            {
                if (!dictionary.ContainsValue(c))
                {
                    dictionary[c] = 1;
                }
                else
                {
                    dictionary[c] = dictionary[c] + 1;
                }
            }
            if (dictionary.Values.Any(v => v == 3))
            {
                value = new HandValue() { Rank = 3, Ordered_Values = cardNumericValues.ToList() };
                return true;
            }
            value = null;
            return false;
        }
        public bool TwoPair(PlayerHand playerhand, out HandValue value)
        {
            var cardNumericValues = playerhand.Hand.Select(c => (int)c.Number).OrderByDescending(v => v);
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            foreach (int c in cardNumericValues)
            {
                if (!dictionary.ContainsValue(c))
                {
                    dictionary[c] = 1;
                }
                else
                {
                    dictionary[c] = dictionary[c] + 1;
                }
            }
            if (dictionary.Values.Count(v => v == 2) == 2)
            {
                value = new HandValue() { Rank = 2, Ordered_Values = cardNumericValues.ToList() };
                return true;
            }
            value = null;
            return false;
        }
        public bool Onepair(PlayerHand playerhand, out HandValue value)
        {
            var cardNumericValues = playerhand.Hand.Select(c => (int)c.Number).OrderByDescending(v => v);
            HashSet<int> cardsInHand = new HashSet<int>(cardNumericValues);

            if (cardsInHand.Count < playerhand.Hand.Count)
            {
                value = new HandValue() { Rank = 1, Ordered_Values = cardNumericValues.ToList() };
                return true;
            }

            value = null;
            return false;
        }
        public bool HighCard(PlayerHand playerhand, out HandValue value)
        {
            var cardNumericValues = playerhand.Hand.Select(c => (int)c.Number).OrderByDescending(v => v);
            var cardNumericValue = playerhand.Hand.Select(c => (int)c.Number).Max();
            if (cardNumericValue == cardNumericValues.Max())
            {
                value = new HandValue() { Rank = 0, Ordered_Values = cardNumericValues.ToList() };
                return true;
            }

            value = null;
            return false;
        }
    }
}
