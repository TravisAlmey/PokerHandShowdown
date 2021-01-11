using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandShowdown.DataModels;
using PokerHandShowdown.Hands;
using System;
using System.Collections.Generic;

namespace PokerHandShowdownTests.HandTypes
{
    [TestClass]
    public class FlushTest
    {
        [TestMethod]
        public void Constructor_WithValidCardsForFlush_StoresSortedFlushCards()
        {
            List<Card> cards = TestUtil.CreateTestFlushCards(Suit.Club, new int[] { 10, 13, 3, 5, 4 });
            Flush hand = new Flush(cards);

            Assert.AreEqual(hand.flushCards[0].Value, CardValue.Ace);
            Assert.AreEqual(hand.flushCards[1].Value, CardValue.Jack);
            Assert.AreEqual(hand.flushCards[2].Value, CardValue.Six);
            Assert.AreEqual(hand.flushCards[3].Value, CardValue.Five);
            Assert.AreEqual(hand.flushCards[4].Value, CardValue.Four);
        }

        [TestMethod]
        public void Constructor_WithInvalidCardsForFlush_ThrowsException()
        {
            List<Card> cards = new List<Card>
            {
                new Card(CardValue.Five, Suit.Club),
                new Card(CardValue.Seven, Suit.Club),
                new Card(CardValue.Nine, Suit.Club),
                new Card(CardValue.Jack, Suit.Club),
                new Card(CardValue.Queen, Suit.Heart)
            };
            Flush hand;

            Assert.ThrowsException<Exception>(() => { hand = new Flush(cards); });
        }

        [TestMethod]
        public void Constructor_WithMoreCardsThanNeededCardsForFlush_StoresOnlyHighestValueSortedFlushCards()
        {
            List<Card> cards = new List<Card>
            {
                new Card(CardValue.Two, Suit.Spade),
                new Card(CardValue.Three, Suit.Club),
                new Card(CardValue.Five, Suit.Club),
                new Card(CardValue.Six, Suit.Club),
                new Card(CardValue.Seven, Suit.Club),
                new Card(CardValue.Seven, Suit.Diamond),
                new Card(CardValue.Nine, Suit.Club),
                new Card(CardValue.Jack, Suit.Club),
                new Card(CardValue.Queen, Suit.Heart)
            };
            Flush hand = new Flush(cards);

            Assert.AreEqual(hand.flushCards.Count, 5);
            Assert.AreEqual(hand.flushCards[0].Value, CardValue.Jack);
            Assert.AreEqual(hand.flushCards[1].Value, CardValue.Nine);
            Assert.AreEqual(hand.flushCards[2].Value, CardValue.Seven);
            Assert.AreEqual(hand.flushCards[3].Value, CardValue.Six);
            Assert.AreEqual(hand.flushCards[4].Value, CardValue.Five);

            foreach (Card card in hand.flushCards)
            {
                Assert.AreEqual(card.Suit, Suit.Club);
            }
        }

        [TestMethod]
        public void Constructor_WithMultipleValidFlushSetsInHand_StoresOnlyHighestValueSortedFlushCards()
        {
            List<Card> cards = new List<Card>
            {
                new Card(CardValue.Five, Suit.Club),
                new Card(CardValue.Six, Suit.Club),
                new Card(CardValue.Seven, Suit.Club),
                new Card(CardValue.Nine, Suit.Club),
                new Card(CardValue.Jack, Suit.Club),
                new Card(CardValue.Four, Suit.Heart),
                new Card(CardValue.Six, Suit.Heart),
                new Card(CardValue.Seven, Suit.Heart),
                new Card(CardValue.Nine, Suit.Heart),
                new Card(CardValue.Jack, Suit.Heart)
            };

            Flush hand = new Flush(cards);

            Assert.AreEqual(hand.flushCards.Count, 5);
            Assert.AreEqual(hand.flushCards[0].Value, CardValue.Jack);
            Assert.AreEqual(hand.flushCards[1].Value, CardValue.Nine);
            Assert.AreEqual(hand.flushCards[2].Value, CardValue.Seven);
            Assert.AreEqual(hand.flushCards[3].Value, CardValue.Six);
            Assert.AreEqual(hand.flushCards[4].Value, CardValue.Five);

            foreach (Card card in hand.flushCards)
            {
                Assert.AreEqual(card.Suit, Suit.Club);
            }
        }

        [TestMethod]
        public void CompareTo_WithIdenticalFlushHands_ReturnsZero()
        {
            List<Card> cards = TestUtil.CreateTestFlushCards(Suit.Club, new int[] { 13, 10, 3, 5, 4 });
            Flush hand1 = new Flush(cards);
            Flush hand2 = new Flush(cards);

            Assert.AreEqual(hand1.CompareTo(hand2), 0);
        }

        [TestMethod]
        public void CompareTo_WithEquivalentFlushHands_ReturnsZero()
        {
            List<Card> cards1 = TestUtil.CreateTestFlushCards(Suit.Club, new int[] { 13, 10, 3, 5, 4 });
            Flush hand1 = new Flush(cards1);

            List<Card> cards2 = TestUtil.CreateTestFlushCards(Suit.Heart, new int[] { 4, 3, 5, 10, 13 });
            Flush hand2 = new Flush(cards2);

            Assert.AreEqual(hand1.CompareTo(hand2), 0);
        }

        [TestMethod]
        public void CompareTo_WithDifferentFlushHands_ReturnsNonZero()
        {
            List<Card> cards1 = TestUtil.CreateTestFlushCards(Suit.Club, new int[] { 10, 9, 5, 4, 3 });
            Flush hand1 = new Flush(cards1);

            List<Card> cards2 = TestUtil.CreateTestFlushCards(Suit.Heart, new int[] { 10, 8, 6, 4, 3 });
            Flush hand2 = new Flush(cards2);

            Assert.IsTrue(hand1.CompareTo(hand2) > 0);
            Assert.IsTrue(hand2.CompareTo(hand1) < 0);
        }

        [TestMethod]
        public void CompareTo_WithLargeHands_ThatAreIdentical_ReturnsZero()
        {
            List<Card> cards = TestUtil.CreateTestFlushCards(Suit.Club, new int[] { 13, 12, 11, 9, 8, 6, 5, 4, 2, 1 });
            Flush hand1 = new Flush(cards);
            Flush hand2 = new Flush(cards);

            Assert.IsTrue(hand1.CompareTo(hand2) == 0);
        }

        [TestMethod]
        public void CompareTo_WithLargeHands_ThatHaveIdenticalHighestValues_ReturnsZero()
        {
            List<Card> cards1 = TestUtil.CreateTestFlushCards(Suit.Club, new int[] { 13, 12, 11, 9, 8, 6, 5, 4, 2, 1 });
            Flush hand1 = new Flush(cards1);
            List<Card> cards2 = TestUtil.CreateTestFlushCards(Suit.Heart, new int[] { 13, 12, 11, 9, 8, 7, 5, 4, 3, 1 });
            Flush hand2 = new Flush(cards2);

            Assert.IsTrue(hand1.CompareTo(hand2) == 0);
        }

        [TestMethod]
        public void CompareTo_WithLargeHands_ThatHaveDifferingHighestValues_ReturnsNonZero()
        {
            List<Card> cards1 = TestUtil.CreateTestFlushCards(Suit.Club, new int[] { 13, 12, 11, 10, 8, 6, 5, 4, 2, 1 });
            Flush hand1 = new Flush(cards1);
            List<Card> cards2 = TestUtil.CreateTestFlushCards(Suit.Heart, new int[] { 13, 12, 11, 9, 8, 7, 5, 4, 3, 1 });
            Flush hand2 = new Flush(cards2);

            Assert.IsTrue(hand1.CompareTo(hand2) > 0);
            Assert.IsTrue(hand2.CompareTo(hand1) < 0);
        }

        [TestMethod]
        public void CompareTo_ComparingAgainstNonFlushHand_ThrowsException()
        {
            List<Card> cards1 = TestUtil.CreateTestFlushCards(Suit.Club, new int[] { 10, 13, 3, 5, 4 });
            Flush flushHand = new Flush(cards1);
            List<Card> cards2 = TestUtil.CreateDefaultPairCards();
            Pair pairHand = new Pair(cards2);

            Assert.ThrowsException<Exception>(() => flushHand.CompareTo(pairHand));
        }
    }
}
