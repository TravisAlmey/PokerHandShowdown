using PokerHandShowdown.DataModels;
using PokerHandShowdown.Utilities;
using System.Collections.Generic;

namespace PokerHandShowdown
{
    public class Main
    {
        public List<Player> GetWinningPlayers(Dictionary<string, List<Card>> gameData)
        {
            PlayerUtils.ValidateGameData(gameData);

            List<Player> players = PlayerUtils.GeneratePlayers(gameData);

            List<Player> possibleWinners = PlayerUtils.GetPossibleWinningPlayers(players);

            List<Player> winningPlayers = PlayerUtils.ResolveTies(possibleWinners);

            return winningPlayers;
        }
    }
}
