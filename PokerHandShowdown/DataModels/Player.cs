using PokerHandShowdown.Hands;
using PokerHandShowdown.Utilities;
using System.Collections.Generic;

namespace PokerHandShowdown.DataModels
{
    public struct Player
    {
        public string Name { get; }
        public Hand HandOfCards;

        public Player(string name, List<Card> cards)
        {
            this.Name = name;
            this.HandOfCards = HandFactory.GetHand(cards);
        }
    }
}
