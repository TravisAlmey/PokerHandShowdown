using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandShowdown.DataModels;
using PokerHandShowdown.Hands;
using System.Collections.Generic;

namespace PokerHandShowdownTests.HandTypes
{
    [TestClass]
    public class HighCardTest
    {
        [TestMethod]
        public void Constructor_WithValidCardsForHighCard_StoresSortedHighCardCards()
        {
            List<Card> cards = TestUtil.CreateDefaultHighCardCards();
            HighCard hand = new HighCard(cards);

            Assert.AreEqual(hand.sortedCards[0], new Card(CardValue.Jack, Suit.Heart));
            Assert.AreEqual(hand.sortedCards[1], new Card(CardValue.Nine, Suit.Club));
            Assert.AreEqual(hand.sortedCards[2], new Card(CardValue.Eight, Suit.Diamond));
            Assert.AreEqual(hand.sortedCards[3], new Card(CardValue.Seven, Suit.Spade));
            Assert.AreEqual(hand.sortedCards[4], new Card(CardValue.Four, Suit.Heart));
        }

        [TestMethod]
        public void CompareTo_ComparesHighCardHands_ReturnsComparison()
        {
            List<Card> cards1 = TestUtil.CreateDefaultHighCardCards();
            HighCard hand1 = new HighCard(cards1);

            List<Card> cards2 = new List<Card>
            {
            new Card(CardValue.Jack, Suit.Heart),
                new Card(CardValue.Seven, Suit.Spade),
                new Card(CardValue.Nine, Suit.Club),
                new Card(CardValue.Eight, Suit.Diamond),
                new Card(CardValue.Three, Suit.Heart)
            };
            HighCard hand2 = new HighCard(cards2);

            Assert.IsTrue(hand1.CompareTo(hand2) > 0);
        }
    }
}
