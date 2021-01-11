using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandShowdown.DataModels;
using PokerHandShowdown.Hands;
using System.Collections.Generic;

namespace PokerHandShowdownTests.HandTypes
{
    [TestClass]
    public class ThreeOfAKindTest
    {
        [TestMethod]
        public void Constructor_WithValidCardsForThreeOfAKind_StoresSortedThreeOfAKindCards()
        {
            List<Card> cards = TestUtil.CreateDefaultThreeOfAKindCards();
            ThreeOfAKind hand = new ThreeOfAKind(cards);

            Assert.IsTrue(hand.highestThreeOfAKind.Contains(new Card(CardValue.Seven, Suit.Heart)));
            Assert.IsTrue(hand.highestThreeOfAKind.Contains(new Card(CardValue.Seven, Suit.Spade)));
            Assert.IsTrue(hand.highestThreeOfAKind.Contains(new Card(CardValue.Seven, Suit.Club)));
            Assert.AreEqual(hand.kickerCards[0], new Card(CardValue.Eight, Suit.Diamond));
            Assert.AreEqual(hand.kickerCards[1], new Card(CardValue.Four, Suit.Heart));
        }

        [TestMethod]
        public void CompareTo_ComparesThreeOfAKindHands_ReturnsComparison()
        {
            List<Card> cards1 = TestUtil.CreateDefaultThreeOfAKindCards();
            ThreeOfAKind hand1 = new ThreeOfAKind(cards1);

            List<Card> cards2 = new List<Card>
            {
                new Card(CardValue.Five, Suit.Heart),
                new Card(CardValue.Five, Suit.Spade),
                new Card(CardValue.Five, Suit.Club),
                new Card(CardValue.Seven, Suit.Diamond),
                new Card(CardValue.Three, Suit.Heart)
            };
            ThreeOfAKind hand2 = new ThreeOfAKind(cards2);

            Assert.IsTrue(hand1.CompareTo(hand2) > 0);
        }
    }
}

