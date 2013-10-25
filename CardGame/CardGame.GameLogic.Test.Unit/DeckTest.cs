using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardGame.GameLogic.Test.Unit
{
    public class FakeDeck : Deck
    {
        public IEnumerable<Card> FakeCards {get {return this.Cards;}}
    }
    [TestClass]
    public class DeckTest
    {
        [TestMethod]
        public void NewDeckShouldHave52Cards()
        {
            var deck = new FakeDeck();

            Assert.AreEqual(52, deck.FakeCards.Count(), "Deck should have 52 cards");
        }

        [TestMethod]
        public void NewDeckShouldHave14OfEachSuit()
        {
            var deck = new FakeDeck();

            Assert.AreEqual(13, deck.FakeCards.Count(c => c.Suit == Suit.Hearts));
            Assert.AreEqual(13, deck.FakeCards.Count(c => c.Suit == Suit.Diamonds));
            Assert.AreEqual(13, deck.FakeCards.Count(c => c.Suit == Suit.Spades));
            Assert.AreEqual(13, deck.FakeCards.Count(c => c.Suit == Suit.Clubs));
        }

        [TestMethod]
        public void ShuffleShoouldRandomizeDeckOrder()
        {
            var deck = new FakeDeck();
            var cardsAtStart = deck.FakeCards.ToArray();

            deck.Shuffle();
            var cardsAfterShuffle= deck.FakeCards.ToArray();

            bool orderChanged = false;
            for (var i = 0; i < cardsAtStart.Length; ++i)
            {
                if (cardsAtStart[i] != cardsAfterShuffle[i])
                {
                    orderChanged = true;
                }
            }
            Assert.IsTrue(orderChanged);    
        }
        [TestMethod]
        public void ShuffleDeckSizeIsSameAfterShuffling()
        {
            var deck = new FakeDeck();
            var cardsAtStart = deck.FakeCards.ToArray();

            deck.Shuffle();
            var cardsAfterShuffle= deck.FakeCards.ToArray();

            Assert.AreEqual(cardsAtStart.Count(), cardsAfterShuffle.Count());
        }
        [TestMethod]
        public void ShuffleDeckContainsSameCards()
        {
            var deck = new FakeDeck();
            var cardsAtStart = deck.FakeCards.ToArray();

            deck.Shuffle();
            var cardsAfterShuffle = deck.FakeCards.ToArray();

            Assert.AreEqual(cardsAtStart.Count(), cardsAtStart.Union(cardsAfterShuffle).Count());
        }
    }
}
