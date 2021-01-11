using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandShowdown.DataModels;
using PokerHandShowdown.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHandShowdownTests.Utilities
{
    [TestClass]
    public class HandUtilsTest
    {
        [TestMethod]
        public void CompareSortedCardLists_ReturnsComparison()
        {
            List<Card> cards1 = new List<Card>
            {
                new Card(CardValue.Queen, Suit.Club),
                new Card(CardValue.Jack, Suit.Club),
                new Card(CardValue.Nine, Suit.Club),
                new Card(CardValue.Seven, Suit.Club),
                new Card(CardValue.Five, Suit.Heart)
            };
            List<Card> cards2 = new List<Card>
            {
                new Card(CardValue.Queen, Suit.Club),
                new Card(CardValue.Jack, Suit.Club),
                new Card(CardValue.Nine, Suit.Club),
                new Card(CardValue.Seven, Suit.Club),
                new Card(CardValue.Four, Suit.Heart)
            };

            Assert.IsTrue(HandUtils.CompareSortedCardLists(cards1, cards2) > 0);
        }

        [TestMethod]
        public void GetHighestValueDuplicateSet_ReturnsHighestValueSetOfCardsWithTheSpecifiedNumberOfDuplicates()
        {
            List<Card> cards = new List<Card>
            {
                new Card(CardValue.Queen, Suit.Club),
                new Card(CardValue.Jack, Suit.Club),
                new Card(CardValue.Queen, Suit.Heart),
                new Card(CardValue.Queen, Suit.Diamond),
                new Card(CardValue.Jack, Suit.Heart)
            };

            List<Card> result = HandUtils.GetHighestValueDuplicateSet(cards, 2);

            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Value, CardValue.Jack);
            Assert.AreEqual(result[1].Value, CardValue.Jack);
        }

        [TestMethod]
        public void GetHighestValueFlush_ReturnsHighestValueSetOfCardsSatisfyingAFlushOfAtLeastTheSpecifiedSize()
        {
            List<Card> cards = TestUtil.CreateTestFlushCards(Suit.Diamond, new int[] { 2, 4, 6, 8, 10 });

            List<Card> result = HandUtils.GetHighestValueFlush(cards, 5);

            Assert.AreEqual(result.Count, 5);
        }


        [TestMethod]
        public void GetCardsNotInSet_ReturnsASetOfCardsWithTheSecondSetExcluded()
        {
            List<Card> cards1 = TestUtil.CreateTestFlushCards(Suit.Diamond, new int[] { 2, 4, 6, 8, 10 });
            List<Card> cards2 = TestUtil.CreateTestFlushCards(Suit.Diamond, new int[] { 2, 4, 8, 10, 12 });

            List<Card> result = HandUtils.GetCardsNotInSet(cards1, cards2);

            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0], new Card(CardValue.Seven, Suit.Diamond));
        }

        [TestMethod]
        public void GetHighestValueSortedSubset_GetsASpecifiedSizeSubsetOfTheCardsWithTheHighestValue()
        {
            List<Card> cards = TestUtil.CreateTestFlushCards(Suit.Diamond, new int[] { 2, 4, 6, 8, 10 });

            List<Card> result = HandUtils.GetHighestValueSortedSubset(3, cards);

            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual(result[0], new Card(CardValue.Jack, Suit.Diamond));
            Assert.AreEqual(result[1], new Card(CardValue.Nine, Suit.Diamond));
            Assert.AreEqual(result[2], new Card(CardValue.Seven, Suit.Diamond));
        }

        [TestMethod]
        public void GetCountsOfCardsByValue_ReturnsADictionaryMappingValuesOfCardsToTheirFrequency()
        {
            List<Card> cards = new List<Card>
            {
                new Card(CardValue.Queen, Suit.Club),
                new Card(CardValue.Jack, Suit.Club),
                new Card(CardValue.Queen, Suit.Heart),
                new Card(CardValue.Queen, Suit.Diamond),
                new Card(CardValue.Jack, Suit.Heart)
            };

            Dictionary<CardValue, int> result = HandUtils.GetCountsOfCardsByValue(cards);

            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[CardValue.Queen], 3);
            Assert.AreEqual(result[CardValue.Jack], 2);
        }

        [TestMethod]
        public void GetCountsOfCardsBySuit_ReturnsADictionaryMappingSuitsOfCardsToTheirFrequency()
        {
            List<Card> cards = new List<Card>
            {
                new Card(CardValue.Four, Suit.Club),
                new Card(CardValue.Jack, Suit.Club),
                new Card(CardValue.Ten, Suit.Club),
                new Card(CardValue.Queen, Suit.Club),
                new Card(CardValue.Jack, Suit.Heart)
            };

            Dictionary<Suit, int> result = HandUtils.GetCountsOfCardsBySuit(cards);

            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[Suit.Club], 4);
            Assert.AreEqual(result[Suit.Heart], 1);
        }
    }
}
