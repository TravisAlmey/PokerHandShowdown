using PokerHandShowdown.DataModels;
using System;

namespace PokerHandShowdown.Hands
{
    public abstract class Hand : IComparable<Hand>
    {
        public abstract int CompareTo(Hand other);

        public abstract HandType GetHandType();
    }
}
