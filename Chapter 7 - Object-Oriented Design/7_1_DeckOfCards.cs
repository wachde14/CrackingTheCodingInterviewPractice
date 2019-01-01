using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter_7___Object_Oriented_Design
{
    /// <summary>
    /// Deck of Cards: Design the data structures for a generic deck of cards. Explain how you would
    /// subclass the data structures to implement blackjack.
    /// </summary>
    public enum Value { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King };

    public enum Suit { Diamond, Heart, Club, Spade };

    public class Card
    {
        public Value Value;
        public Suit Suit;

        public Card(Value value, Suit suit)
        {
            this.Value = value;
            this.Suit = suit;
        }
    }

    public class Deck
    {
        private readonly Random randCard = new Random(DateTime.Now.Millisecond);

        public List<Card> CreateStandardDeck()
        {
            var cardValues = Enum.GetValues(typeof(Value));
            var suits = Enum.GetValues(typeof(Suit));

            List<Card> standardDeck = new List<Card>();
            foreach (Value currCardValue in cardValues)
            {
                foreach (Suit currSuit in suits)
                {
                    standardDeck.Add(new Card(currCardValue, currSuit));
                }
            }
            return standardDeck;
        }
    }

    public class _7_1_DeckOfCardsTests
    {
        [Test]
        public void _7_1_DeckClass_WithValidCards_ShouldCreate52UniqueCards()
        {
            Deck testDeck = new Deck();

            List<Card> cards = testDeck.CreateStandardDeck();
            int uniqueCardCount = cards.Distinct().Count();

            Assert.AreEqual(52, uniqueCardCount);
        }
    }
}

