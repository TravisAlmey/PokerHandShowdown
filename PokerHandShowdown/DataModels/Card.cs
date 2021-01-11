using System;

namespace PokerHandShowdown.DataModels
{
    public struct Card : IComparable<Card>
    {
        public Suit Suit { get; }
        public CardValue Value { get; }

        public Card(CardValue value, Suit suit)
        {
            this.Suit = suit;
            this.Value = value;
        }

        public int CompareTo(Card other)
        {
            return this.Value - other.Value;
        }
    }
}
