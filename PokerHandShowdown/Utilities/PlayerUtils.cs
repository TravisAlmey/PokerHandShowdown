using PokerHandShowdown.DataModels;
using PokerHandShowdown.Hands;
using System;
using System.Collections.Generic;

namespace PokerHandShowdown.Utilities
{
    public static class PlayerUtils
    {
        public static void ValidateGameData(Dictionary<string, List<Card>> gameData)
        {
            /* There was't much in the requirements to specify what the game data should or should not contain, however the input data should be
             * sanitized before being passed in. In a real project this would be a requirement requested from someone on the product side. 
             * I have left in this stub method as a placeholder.
             */
        }

        public static List<Player> GeneratePlayers(Dictionary<string, List<Card>> playerData)
        {
            List<Player> players = new List<Player>();

            foreach (KeyValuePair<string, List<Card>> data in playerData)
            {
                players.Add(new Player(data.Key, data.Value));
            }

            return players;
        }

        public static List<Player> GetPossibleWinningPlayers(List<Player> players)
        {
            HandType bestHandType = GetBestHandType(players);

            return players.FindAll(player => player.HandOfCards.GetHandType() == bestHandType);
        }

        public static List<Player> ResolveTies(List<Player> players)
        {
            if (players.Count == 1)
            {
                return players;
            }

            List<Player> winningPlayers = new List<Player>();
            winningPlayers.Add(players[0]);

            for (int i = 1; i < players.Count; i++)
            {
                int comparison = players[i].HandOfCards.CompareTo(winningPlayers[0].HandOfCards);

                if (comparison == 0)
                {
                    winningPlayers.Add(players[i]);
                }
                else if (comparison > 0)
                {
                    winningPlayers.Clear();
                    winningPlayers.Add(players[i]);
                }
            }

            return winningPlayers;
        }

        private static HandType GetBestHandType(List<Player> players)
        {
            if (players.Count == 1)
            {
                return players[0].HandOfCards.GetHandType();
            }

            HandType bestHandType = players[0].HandOfCards.GetHandType();

            for (int i = 1; i < players.Count; i++)
            {
                HandType handType = players[i].HandOfCards.GetHandType();

                if (handType > bestHandType)
                {
                    bestHandType = handType;
                }
            }

            return bestHandType;
        }
    }
}
