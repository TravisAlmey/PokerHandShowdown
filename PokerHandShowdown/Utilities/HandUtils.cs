using PokerHandShowdown.DataModels;
using System;
using System.Collections.Generic;

namespace PokerHandShowdown.Utilities
{
    public static class HandUtils
    {
        public static int CompareSortedCardLists(List<Card> cardListA, List<Card> cardListB)
        {
            for (int i = 0; i < cardListA.Count; i++)
            {
                if (cardListA[i].CompareTo(cardListB[i]) != 0)
                {
                    return cardListA[i].CompareTo(cardListB[i]);
                }
            }
            return 0;
        }

        public static List<Card> GetHighestValueDuplicateSet(List<Card> cards, int duplicateSetSize)
        {
            Dictionary<CardValue, int> countsOfCardValues = GetCountsOfCardsByValue(cards);

            List<CardValue> valuesOfDuplicates = new List<CardValue>();
            foreach (KeyValuePair<CardValue, int> count in countsOfCardValues)
            {
                if (count.Value == duplicateSetSize)
                {
                    valuesOfDuplicates.Add(count.Key);
                }
            }

            if (valuesOfDuplicates.Count == 0)
            {
                throw new Exception("Expected " + duplicateSetSize + " cards with same value but was not found");
            }
            else if (valuesOfDuplicates.Count == 1)
            {
                return GetCardsMatchingValue(valuesOfDuplicates[0], cards);
            }
            else
            {
                return GetCardsMatchingValue(GetHighestCardValue(valuesOfDuplicates), cards);
            }
        }

        public static List<Card> GetHighestValueFlush(List<Card> cards, int numberOfCardsForFlush)
        {
            Dictionary<Suit, int> countsOfCardsBySuit = GetCountsOfCardsBySuit(cards);

            List<Suit> suitsWithFlush = new List<Suit>();
            foreach (KeyValuePair<Suit, int> count in countsOfCardsBySuit)
            {
                if (count.Value >= numberOfCardsForFlush)
                {
                    suitsWithFlush.Add(count.Key);
                }
            }

            if (suitsWithFlush.Count == 0)
            {
                throw new Exception("Expected cards to be flush but was not");
            }
            else if (suitsWithFlush.Count == 1)
            {
                List<Card> flushCards = HandUtils.GetCardsMatchingSuit(suitsWithFlush[0], cards);
                return HandUtils.GetHighestValueSortedSubset(numberOfCardsForFlush, flushCards);
            }
            else
            {
                Dictionary<Suit, List<Card>> validFlushSets = new Dictionary<Suit, List<Card>>();
                foreach (Suit suit in suitsWithFlush)
                {
                    List<Card> flushCards = HandUtils.GetCardsMatchingSuit(suit, cards);
                    flushCards = HandUtils.GetHighestValueSortedSubset(numberOfCardsForFlush, flushCards);
                    validFlushSets.Add(suit, flushCards);
                }

                List<Card> bestFlush = null;
                foreach (List<Card> flush in validFlushSets.Values)
                {
                    if (bestFlush == null || HandUtils.CompareSortedCardLists(flush, bestFlush) > 0)
                    {
                        bestFlush = flush;
                    }
                }

                return bestFlush;
            }
        }

        public static List<Card> GetCardsNotInSet(List<Card> cards, List<Card> cardsToRemove)
        {
            List<Card> remainingCards = cards; // this should be a deep copy, but I was unable to find a straightforward way to implement a deep copy
            foreach (Card card in cardsToRemove)
            {
                if (remainingCards.Contains(card))
                {
                    remainingCards.Remove(card);
                }
            }
            return remainingCards;
        }

        public static List<Card> GetHighestValueSortedSubset(int subsetSize, List<Card> cards)
        {
            cards.Sort();
            cards.Reverse();

            if (cards.Count <= subsetSize)
            {
                return cards;
            }

            return cards.GetRange(0, subsetSize);

        }

        public static Dictionary<CardValue, int> GetCountsOfCardsByValue(List<Card> cards)
        {
            Dictionary<CardValue, int> countsOfCardValues = new Dictionary<CardValue, int>();
            foreach (Card card in cards)
            {
                if (countsOfCardValues.ContainsKey(card.Value))
                {
                    countsOfCardValues[card.Value]++;
                }
                else
                {
                    countsOfCardValues[card.Value] = 1;
                }
            }
            return countsOfCardValues;
        }

        public static Dictionary<Suit, int> GetCountsOfCardsBySuit(List<Card> cards)
        {
            Dictionary<Suit, int> countsOfCardsBySuit = new Dictionary<Suit, int>();
            foreach (Card card in cards)
            {
                if (countsOfCardsBySuit.ContainsKey(card.Suit))
                {
                    countsOfCardsBySuit[card.Suit]++;
                }
                else
                {
                    countsOfCardsBySuit[card.Suit] = 1;
                }
            }
            return countsOfCardsBySuit;
        }

        private static List<Card> GetCardsMatchingValue(CardValue value, List<Card> cards)
        {
            return cards.FindAll(card => card.Value == value);
        }

        private static List<Card> GetCardsMatchingSuit(Suit suit, List<Card> cards)
        {
            return cards.FindAll(card => card.Suit == suit);
        }

        private static CardValue GetHighestCardValue(List<CardValue> values)
        {
            CardValue highestValue = values[0];
            for (int i = 1; i < values.Count; i++)
            {
                if (values[i] > highestValue)
                {
                    highestValue = values[i];
                }
            }

            return highestValue;
        }
    }
}
