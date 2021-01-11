using PokerHandShowdown.DataModels;
using PokerHandShowdown.Utilities;
using System;
using System.Collections.Generic;

namespace PokerHandShowdown.Hands
{
    public class HighCard : Hand
    {
        private readonly int handSize = 5;

        public List<Card> sortedCards;

        public HighCard(List<Card> cards)
        {
            this.sortedCards = HandUtils.GetHighestValueSortedSubset(this.handSize, cards);
        }

        public override int CompareTo(Hand other)
        {
            if (!(other is HighCard))
            {
                throw new Exception("Cannot compare high card hand not non-high card hand");
            }

            return HandUtils.CompareSortedCardLists(this.sortedCards, ((HighCard) other).sortedCards);
        }

        public override HandType GetHandType()
        {
            return HandType.HighCard;
        }
    }
}
