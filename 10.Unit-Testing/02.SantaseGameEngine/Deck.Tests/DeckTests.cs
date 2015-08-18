namespace Deck.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    using Santase.Logic.Cards;

    [TestFixture]
    public class DeckTests
    {
        [Test]
        public void Test_NewDeckShouldHaveTwentyFourCards()
        {
            Deck someDeck = new Deck();
            Assert.AreEqual(24, someDeck.CardsLeft);
        }

        [TestCase(CardType.Nine)]
        [TestCase(CardType.Ten)]
        [TestCase(CardType.Jack)]
        [TestCase(CardType.Queen)]
        [TestCase(CardType.King)]
        [TestCase(CardType.Ace)]
        public void Test_EachDeckHaveFourCardsFromEachType(CardType type)
        {
            Deck someDeck = new Deck();
            byte counter = 0;
            for (int i = 0; i < 24; i++)
            {
                if (someDeck.GetNextCard().Type == type)
                {
                    counter++;
                }
            }
            Assert.AreEqual(4, counter);
        }

        [TestCase(CardSuit.Club)]
        [TestCase(CardSuit.Diamond)]
        [TestCase(CardSuit.Heart)]
        [TestCase(CardSuit.Spade)]
        public void Test_EachDeckHaveSixOneSuiteCards(CardSuit suit)
        {
            Deck someDeck = new Deck();
            byte counter = 0;
            for (int i = 0; i < 24; i++)
            {
                if (someDeck.GetNextCard().Suit == suit)
                {
                    counter++;
                }
            }
            Assert.AreEqual(6, counter);
        }

        [Test]
        public void Test_SettingNewTrumpCard()
        {
            Deck someDeck = new Deck();
            Card newTrumpCard = new Card(CardSuit.Heart, CardType.King);
            someDeck.ChangeTrumpCard(newTrumpCard);
            Assert.AreSame(newTrumpCard, someDeck.GetTrumpCard);
        }

        [Test]
        public void Test_GettingCardShouldDecreaseTheDeck()
        {
            Deck someDeck = new Deck();
            someDeck.GetNextCard();
            Assert.AreNotEqual(24, someDeck.CardsLeft);
        }

        [Test]
        public void Test_DeckIsEmptyAfterAllCardsGotten()
        {
            Deck someDeck = new Deck();
            for (int i = 0; i < 24; i++)
            {
                someDeck.GetNextCard();
            }
            Assert.AreEqual(0, someDeck.CardsLeft);
        }

        [Test]
        public void Test_ThrowExceptionAfterTryingToGetCardFromEmptyDeck()
        {
            Deck someDeck = new Deck();
            for (int i = 0; i < 24; i++)
            {
                someDeck.GetNextCard();
            }
            Assert.Throws(typeof(Santase.Logic.InternalGameException), () => {someDeck.GetNextCard();}, "Boo!");
        }
    }
}
