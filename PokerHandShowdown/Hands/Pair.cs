using PokerHandShowdown.DataModels;
using PokerHandShowdown.Utilities;
using System;
using System.Collections.Generic;

namespace PokerHandShowdown.Hands
{
    public class Pair : Hand
    {
        private readonly int cardsInPair = 2;
        private readonly int cardsInPairKicker = 3;

        public List<Card> highestPair;
        public List<Card> kickerCards;

        public Pair(List<Card> cards)
        {
            this.highestPair = HandUtils.GetHighestValueDuplicateSet(cards, cardsInPair);
            List<Card> cardsNotInPair = HandUtils.GetCardsNotInSet(cards, this.highestPair);
            this.kickerCards = HandUtils.GetHighestValueSortedSubset(cardsInPairKicker, cardsNotInPair);
        }

        public override int CompareTo(Hand other)
        {
            if (!(other is Pair))
            {
                throw new Exception("Cannot compare pair hand not non-pair hand");
            }

            Pair otherPair = (Pair) other;

            int pairComparison = this.highestPair[0].CompareTo(otherPair.highestPair[0]);

            if (pairComparison != 0)
            {
                return pairComparison;
            }
            else
            {
                return HandUtils.CompareSortedCardLists(this.kickerCards, otherPair.kickerCards);
            }
        }

        public override HandType GetHandType()
        {
            return HandType.Pair;
        }
    }
}
