using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandShowdown.DataModels;

namespace PokerHandShowdownTests.DataModels
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void CompareTo_ReturnsComparisonOfCardValues()
        {
            Card card1 = new Card(CardValue.Ace, Suit.Spade);
            Card card2 = new Card(CardValue.Jack, Suit.Heart);

            Assert.IsTrue(card1.CompareTo(card2) > 0);
        }
    }
}
