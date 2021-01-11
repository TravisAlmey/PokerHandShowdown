using PokerHandShowdown.DataModels;
using PokerHandShowdown.Hands;
using System.Collections.Generic;

namespace PokerHandShowdown.Utilities
{
    public static class HandFactory
    {
        private static readonly int cardsInHand = 5;
        private static readonly int cardsInThreeOfAKind = 3;
        private static readonly int cardsInPair = 2;

        public static Hand GetHand(List<Card> cards)
        {
            if (PlayerHasFlushHand(cards))
            {
                return new Flush(cards);
            }

            if (PlayerHasThreeOfAKindHand(cards))
            {
                return new ThreeOfAKind(cards);
            }

            if (PlayerHasPairHand(cards))
            {
                return new Pair(cards);
            }

            return new HighCard(cards);
        }

        private static bool PlayerHasFlushHand(List<Card> cards)
        {
            Dictionary<Suit, int> countsOfcardsBySuit = HandUtils.GetCountsOfCardsBySuit(cards);
            foreach (int count in countsOfcardsBySuit.Values)
            {
                if (count >= cardsInHand)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool PlayerHasThreeOfAKindHand(List<Card> cards)
        {
            Dictionary<CardValue, int> countOfCardsByValue = HandUtils.GetCountsOfCardsByValue(cards);
            foreach (int count in countOfCardsByValue.Values)
            {
                if (count >= cardsInThreeOfAKind)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool PlayerHasPairHand(List<Card> cards)
        {
            Dictionary<CardValue, int> countOfCardsByValue = HandUtils.GetCountsOfCardsByValue(cards);
            foreach (int count in countOfCardsByValue.Values)
            {
                if (count >= cardsInPair)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
