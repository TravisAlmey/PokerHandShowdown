using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandShowdown.DataModels;
using PokerHandShowdown.Hands;
using PokerHandShowdown.Utilities;
using System.Collections.Generic;

namespace PokerHandShowdownTests.Utilities
{
    [TestClass]
    public class HandFactoryTest
    {
        [TestMethod]
        public void GetHand_GivenAFlush_ReturnsNewFlushHand()
        {
            List<Card> cards = TestUtil.CreateTestFlushCards(Suit.Club, new int[] { 10, 13, 3, 5, 4 });
            Hand hand = HandFactory.GetHand(cards);

            Assert.AreEqual(hand.GetHandType(), HandType.Flush);
        }

        [TestMethod]
        public void GetHand_GivenAThreeOfAKind_ReturnsNewThreeOfAKindHand()
        {
            List<Card> cards = TestUtil.CreateDefaultThreeOfAKindCards();
            Hand hand = HandFactory.GetHand(cards);

            Assert.AreEqual(hand.GetHandType(), HandType.ThreeOfAKind);
        }

        [TestMethod]
        public void GetHand_GivenAPair_ReturnsNewPairHand()
        {
            List<Card> cards = TestUtil.CreateDefaultPairCards();
            Hand hand = HandFactory.GetHand(cards);

            Assert.AreEqual(hand.GetHandType(), HandType.Pair);
        }

        [TestMethod]
        public void GetHand_GivenAHighCardHand_ReturnsNewHighCardHand()
        {
            List<Card> cards = TestUtil.CreateDefaultHighCardCards();
            Hand hand = HandFactory.GetHand(cards);

            Assert.AreEqual(hand.GetHandType(), HandType.HighCard);
        }
    }
}
