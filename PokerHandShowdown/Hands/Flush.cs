using PokerHandShowdown.DataModels;
using PokerHandShowdown.Utilities;
using System;
using System.Collections.Generic;

namespace PokerHandShowdown.Hands
{
    public class Flush : Hand
    {
        private readonly int handSize = 5;

        public List<Card> flushCards;

        public Flush(List<Card> cards)
        {
            this.flushCards = HandUtils.GetHighestValueFlush(cards, handSize); 
        }
        
        public override int CompareTo(Hand other)
        {
            if (!(other is Flush))
            {
                throw new Exception("Cannot compare flush hand not non-flush hand");
            }

            return HandUtils.CompareSortedCardLists(this.flushCards, ((Flush) other).flushCards);
        }

        public override HandType GetHandType()
        {
            return HandType.Flush;
        }
    }
}
