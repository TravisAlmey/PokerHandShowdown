using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandShowdown.DataModels;
using System.Collections.Generic;

namespace PokerHandShowdownTests.DataModels
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void Constructor_CallsHandFactory_GeneratesHand()
        {
            List<Card> cards = TestUtil.CreateDefaultThreeOfAKindCards();
            string testName = "mockname";

            Player testPlayer = new Player(testName, cards);

            Assert.AreEqual(testPlayer.Name, testName);
            Assert.AreEqual(testPlayer.HandOfCards.GetHandType(), HandType.ThreeOfAKind);
        }
    }
}
