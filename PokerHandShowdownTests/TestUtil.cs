using PokerHandShowdown.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHandShowdownTests
{
    static class TestUtil
    {
        public static List<Card> CreateTestFlushCards(Suit suit, int[] values)
        {
            List<Card> cards = new List<Card>();
            foreach (int value in values)
            {
                cards.Add(new Card((CardValue) value, suit));
            }
            return cards;
        }

        public static List<Card> CreateDefaultPairCards()
        {
            List<Card> cards = new List<Card>
            {
                new Card(CardValue.Seven, Suit.Heart),
                new Card(CardValue.Seven, Suit.Spade),
                new Card(CardValue.Three, Suit.Club),
                new Card(CardValue.Eight, Suit.Diamond),
                new Card(CardValue.Four, Suit.Heart)
            };
            return cards;
        }

        public static List<Card> CreateDefaultThreeOfAKindCards()
        {
            List<Card> cards = new List<Card>
            {
                new Card(CardValue.Seven, Suit.Heart),
                new Card(CardValue.Seven, Suit.Spade),
                new Card(CardValue.Seven, Suit.Club),
                new Card(CardValue.Eight, Suit.Diamond),
                new Card(CardValue.Four, Suit.Heart)
            };
            return cards;
        }

        public static List<Card> CreateDefaultHighCardCards()
        {
            List<Card> cards = new List<Card>
            {
                new Card(CardValue.Jack, Suit.Heart),
                new Card(CardValue.Seven, Suit.Spade),
                new Card(CardValue.Nine, Suit.Club),
                new Card(CardValue.Eight, Suit.Diamond),
                new Card(CardValue.Four, Suit.Heart)
            };
            return cards;
        }


    }
}
