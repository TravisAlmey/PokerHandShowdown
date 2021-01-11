using PokerHandShowdown.DataModels;
using PokerHandShowdown.Utilities;
using System;
using System.Collections.Generic;

namespace PokerHandShowdown.Hands
{
    public class ThreeOfAKind : Hand
    {
        private readonly int cardsInThreeOfAKind = 3;
        private readonly int cardsInThreeOfAKindKicker = 2;

        public List<Card> highestThreeOfAKind;
        public List<Card> kickerCards;

        public ThreeOfAKind(List<Card> cards)
        {
            this.highestThreeOfAKind = HandUtils.GetHighestValueDuplicateSet(cards, this.cardsInThreeOfAKind);
            List<Card> cardsNotInThreeOfAKind = HandUtils.GetCardsNotInSet(cards, this.highestThreeOfAKind);
            this.kickerCards = HandUtils.GetHighestValueSortedSubset(cardsInThreeOfAKindKicker, cardsNotInThreeOfAKind);
        }

        public override int CompareTo(Hand other)
        {
            if (!(other is ThreeOfAKind))
            {
                throw new Exception("Cannot compare three-of-a-kind hand not non-three-of-a-kind hand");
            }

            ThreeOfAKind otherThreeOfAKind = (ThreeOfAKind) other; 

            int threeOfAKindComparison = this.highestThreeOfAKind[0].CompareTo(otherThreeOfAKind.highestThreeOfAKind[0]);

            if (threeOfAKindComparison != 0)
            {
                return threeOfAKindComparison;
            }
            else
            {
                return HandUtils.CompareSortedCardLists(this.kickerCards, otherThreeOfAKind.kickerCards);
            }
        }

        public override HandType GetHandType()
        {
            return HandType.ThreeOfAKind;
        }
    }
}