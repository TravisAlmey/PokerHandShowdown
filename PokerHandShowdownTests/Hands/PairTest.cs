using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandShowdown.DataModels;
using PokerHandShowdown.Hands;
using System.Collections.Generic;

namespace PokerHandShowdownTests.HandTypes
{
    [TestClass]
    public class PairTest
    {
        [TestMethod]
        public void Constructor_WithValidCardsForPair_StoresSortedPairCards()
        {
            List<Card> cards = TestUtil.CreateDefaultPairCards();
            Pair hand = new Pair(cards);

            Assert.IsTrue(hand.highestPair.Contains(new Card(CardValue.Seven, Suit.Heart)));
            Assert.IsTrue(hand.highestPair.Contains(new Card(CardValue.Seven, Suit.Spade)));
            Assert.AreEqual(hand.kickerCards[0], new Card(CardValue.Eight, Suit.Diamond));
            Assert.AreEqual(hand.kickerCards[1], new Card(CardValue.Four, Suit.Heart));
            Assert.AreEqual(hand.kickerCards[2], new Card(CardValue.Three, Suit.Club));
        }

        [TestMethod]
        public void CompareTo_ComparesPairHands_ReturnsComparison()
        {
            List<Card> cards1 = TestUtil.CreateDefaultPairCards();
            Pair hand1 = new Pair(cards1);

            List<Card> cards2 = new List<Card>
            {
                new Card(CardValue.Seven, Suit.Heart),
                new Card(CardValue.Seven, Suit.Spade),
                new Card(CardValue.Two, Suit.Club),
                new Card(CardValue.Eight, Suit.Diamond),
                new Card(CardValue.Four, Suit.Heart)
            };
            Pair hand2 = new Pair(cards2);

            Assert.IsTrue(hand1.CompareTo(hand2) > 0);
        }
    }
}
