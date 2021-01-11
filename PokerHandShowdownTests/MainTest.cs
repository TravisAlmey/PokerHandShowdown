using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandShowdown;
using PokerHandShowdown.DataModels;
using System.Collections.Generic;

namespace PokerHandShowdownTests
{
    [TestClass]
    public class MainTest
    {
        [TestMethod]
        public void GetWinningPlayers_WithDifferingTypeHands_ReturnsWinningPlayer()
        {
            Main pokerHandShowDown = new Main();

            string player1Name = "mockPlayer1";
            List<Card> player1Cards = TestUtil.CreateDefaultThreeOfAKindCards();

            string player2Name = "mockPlayer2";
            List<Card> player2Cards = TestUtil.CreateDefaultPairCards();

            Dictionary<string, List<Card>> gameData = new Dictionary<string, List<Card>>
            {
                { player1Name, player1Cards },
                { player2Name, player2Cards }
            };

            List<Player> winningPlayers = pokerHandShowDown.GetWinningPlayers(gameData);

            Assert.AreEqual(winningPlayers.Count, 1);
            Assert.AreEqual(winningPlayers[0].Name, player1Name);
        }

        [TestMethod]
        public void GetWinningPlayers_WithSameTypeHandsWithDifferentValues_ReturnsWinningPlayer()
        {
            Main pokerHandShowDown = new Main();

            string player1Name = "mockPlayer1";
            List<Card> player1Cards = TestUtil.CreateTestFlushCards(Suit.Club, new int[] { 10, 13, 3, 5, 4 });

            string player2Name = "mockPlayer2";
            List<Card> player2Cards = TestUtil.CreateTestFlushCards(Suit.Heart, new int[] { 10, 13, 2, 5, 4 });

            Dictionary<string, List<Card>> gameData = new Dictionary<string, List<Card>>
            {
                { player1Name, player1Cards },
                { player2Name, player2Cards }
            };

            List<Player> winningPlayers = pokerHandShowDown.GetWinningPlayers(gameData);

            Assert.AreEqual(winningPlayers.Count, 1);
            Assert.AreEqual(winningPlayers[0].Name, player1Name);
        }

        [TestMethod]
        public void GetWinningPlayers_WithSameTypeHandsWithSameValues_ReturnsWinningPlayers()
        {
            Main pokerHandShowDown = new Main();

            string player1Name = "mockPlayer1";
            List<Card> player1Cards = TestUtil.CreateTestFlushCards(Suit.Club, new int[] { 10, 13, 3, 5, 4 });

            string player2Name = "mockPlayer2";
            List<Card> player2Cards = TestUtil.CreateTestFlushCards(Suit.Heart, new int[] { 10, 13, 3, 5, 4 });

            Dictionary<string, List<Card>> gameData = new Dictionary<string, List<Card>>
            {
                { player1Name, player1Cards },
                { player2Name, player2Cards }
            };

            List<Player> winningPlayers = pokerHandShowDown.GetWinningPlayers(gameData);

            Assert.AreEqual(winningPlayers.Count, 2);

            Assert.IsNotNull(winningPlayers.Find((player) => player.Name == player1Name));
            Assert.IsNotNull(winningPlayers.Find((player) => player.Name == player2Name));
        }
    }
}
