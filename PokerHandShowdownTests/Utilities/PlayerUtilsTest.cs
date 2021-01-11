using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHandShowdown.DataModels;
using PokerHandShowdown.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHandShowdownTests.Utilities
{
    [TestClass]
    public class PlayerUtilsTest
    {
        [TestMethod]
        public void GeneratePlayers_BuildsAlistOfPlayersFromGameData()
        {
            string player1Name = "mockPlayer1";
            List<Card> player1Cards = TestUtil.CreateDefaultThreeOfAKindCards();

            string player2Name = "mockPlayer2";
            List<Card> player2Cards = TestUtil.CreateDefaultPairCards();

            Dictionary<string, List<Card>> gameData = new Dictionary<string, List<Card>>
            {
                { player1Name, player1Cards },
                { player2Name, player2Cards }
            };

            List<Player> players = PlayerUtils.GeneratePlayers(gameData);

            Assert.AreEqual(players.Count, 2);
            Assert.IsNotNull(players.Find((player) => player.Name == player1Name));
            Assert.IsNotNull(players.Find((player) => player.Name == player2Name));
            Assert.AreEqual(players.Find((player) => player.Name == player1Name).HandOfCards.GetHandType(), HandType.ThreeOfAKind);
            Assert.AreEqual(players.Find((player) => player.Name == player2Name).HandOfCards.GetHandType(), HandType.Pair);
        }

        [TestMethod]
        public void GetPossibleWinningPlayers_ReturnsPlayersWithBestCategoryOfHand()
        {
            string player1Name = "mockPlayer1";
            List<Card> player1Cards = TestUtil.CreateTestFlushCards(Suit.Club, new int[] { 13, 10, 3, 5, 4 });
            Player player1 = new Player(player1Name, player1Cards);

            string player2Name = "mockPlayer2";
            List<Card> player2Cards = TestUtil.CreateDefaultThreeOfAKindCards();
            Player player2 = new Player(player2Name, player2Cards);

            string player3Name = "mockPlayer3";
            List<Card> player3Cards = TestUtil.CreateTestFlushCards(Suit.Heart, new int[] { 6, 1, 3, 5, 4 });
            Player player3 = new Player(player3Name, player3Cards);

            List<Player> players = new List<Player>
            {
                { player1 },
                { player2 },
                { player3 }
            };

            List<Player> result = PlayerUtils.GetPossibleWinningPlayers(players);

            Assert.AreEqual(result.Count, 2);
            Assert.IsNotNull(result.Find((player) => player.Name == player1Name));
            Assert.IsNotNull(result.Find((player) => player.Name == player3Name));
            Assert.AreEqual(result.Find((player) => player.Name == player1Name).HandOfCards.GetHandType(), HandType.Flush);
            Assert.AreEqual(result.Find((player) => player.Name == player3Name).HandOfCards.GetHandType(), HandType.Flush);
        }

        [TestMethod]
        public void ResolveTies_ReturnsPlayersWithBestHand()
        {
            string player1Name = "mockPlayer1";
            List<Card> player1Cards = TestUtil.CreateTestFlushCards(Suit.Club, new int[] { 13, 10, 3, 5, 4 });
            Player player1 = new Player(player1Name, player1Cards);

            string player2Name = "mockPlayer2";
            List<Card> player2Cards = TestUtil.CreateTestFlushCards(Suit.Heart, new int[] { 6, 1, 3, 5, 4 });
            Player player2 = new Player(player2Name, player2Cards);

            List<Player> players = new List<Player>
            {
                { player1 },
                { player2 }
            };

            List<Player> result = PlayerUtils.ResolveTies(players);

            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0].Name, player1Name);
            Assert.AreEqual(result[0].HandOfCards.GetHandType(), HandType.Flush);
        }
    }
}
