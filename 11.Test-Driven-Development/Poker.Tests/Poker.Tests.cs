namespace Poker.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PokerTests
    {
        [TestMethod]
        public void CardToStringMethodShouldReturnTheFullNameOfTheCard()
        {
            const byte CardFacesFirstIndex = 2;
            const byte CardFacesLastIndex = 14;
            const byte CardSuitsFirstIndex = 1;
            const byte CardSuitsLastIndex = 4;  
            for (int i = CardFacesFirstIndex; i <= CardFacesLastIndex; i++)
            {
                for (int j = CardSuitsFirstIndex; j <= CardSuitsLastIndex; j++)
                {
                    Card someCard = new Card(CardFace.Four, CardSuit.Diamonds);
                    Assert.AreEqual(string.Format("{0} of {1}", someCard.Face, someCard.Suit), someCard.ToString());
                }
            }
        }

        [TestMethod]
        public void HandToStringShouldReturnTheNamesOfAllCardsSeparatedWithComma()
        {
            Card[] allCards = new Card[52];
            for (int i = 2; i <= 14; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    allCards[((i - 2) * 4) + (j - 1)] = new Card((CardFace)i, (CardSuit)j);
                }
            }

            List<ICard> cards = new List<ICard>();
            for (int firstCardIndex = 0; firstCardIndex < 52; firstCardIndex++)
            {
                cards.Add(allCards[firstCardIndex]);
                for (int secondCardIndex = 0; secondCardIndex < 52; secondCardIndex++)
                {
                    if (cards.Contains(allCards[secondCardIndex]))
                    {
                        continue;
                    }
                    else
                    {
                        cards.Add(allCards[secondCardIndex]);
                    }

                    for (int thirdCardIndex = 0; thirdCardIndex < 52; thirdCardIndex++)
                    {
                        if (cards.Contains(allCards[thirdCardIndex]))
                        {
                            continue;
                        }
                        else
                        {
                            cards.Add(allCards[thirdCardIndex]);
                        }

                        for (int fourtCardIndex = 0; fourtCardIndex < 52; fourtCardIndex++)
                        {
                            if (cards.Contains(allCards[fourtCardIndex]))
                            {
                                continue;
                            }
                            else
                            {
                                cards.Add(allCards[fourtCardIndex]);
                            }

                            for (int fiftCardIndex = 0; fiftCardIndex < 52; fiftCardIndex++)
                            {
                                if (cards.Contains(allCards[fiftCardIndex]))
                                {
                                    continue;
                                }
                                else
                                {
                                    cards.Add(allCards[fiftCardIndex]);
                                    Hand someHand = new Hand(cards);
                                    string expected = string.Empty;
                                    for (int i = 0; i < someHand.Cards.Count; i++)
                                    {
                                        if (expected != string.Empty)
                                        {
                                            expected += ", ";
                                        }

                                        expected += someHand.Cards[i];
                                    }

                                    Assert.AreEqual(expected, someHand.ToString());
                                }
                            }
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void ValidHandShouldntBeNull()
        {
            List<ICard> cards = null;
            Hand someHand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(false, checker.IsValidHand(someHand));
        }

        [TestMethod]
        public void ValidHandShouldConsistsOfFiveCards()
        {
            List<ICard> cards = new List<ICard>();
            for (int i = 0; i < 3; i++)
            {
                cards.Add(new Card((CardFace)i + 1, CardSuit.Diamonds));
            }

            Hand someHand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(false, checker.IsValidHand(someHand));

            for (int i = 0; i < 3; i++)
            {
                cards.Add(new Card((CardFace)i + 1, CardSuit.Diamonds));
            }

            Hand someOtherHand = new Hand(cards);
            Assert.AreEqual(false, checker.IsValidHand(someOtherHand));
        }

        [TestMethod]
        public void ValidHandShouldConsistsOfDifferentCards()
        {
            List<ICard> cards = new List<ICard>();
            for (int i = 0; i < 3; i++)
            {
                cards.Add(new Card((CardFace)i + 1, CardSuit.Diamonds));
            }

            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            
            Hand someHand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(false, checker.IsValidHand(someHand));
        }

        [TestMethod]
        public void IsFlushIsValidOnlyIfTheHandIsValid()
        {
            List<ICard> cards = new List<ICard>();
            for (int i = 0; i < 3; i++)
            {
                cards.Add(new Card((CardFace)i + 1, CardSuit.Diamonds));
            }

            Hand someHand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(false, checker.IsFlush(someHand));
        }

        [TestMethod]
        public void IsFlushShouldBeTrueIfAllCardsAreOfTheSameSuit()
        {
            for (int i = 1; i <= 4; i++)
            {
                List<ICard> cards = new List<ICard>();
                cards.Add(new Card(CardFace.Jack, (CardSuit)i));
                cards.Add(new Card(CardFace.Eight, (CardSuit)i));
                cards.Add(new Card(CardFace.Queen, (CardSuit)i));
                cards.Add(new Card(CardFace.Six, (CardSuit)i));
                cards.Add(new Card(CardFace.Three, (CardSuit)i));
                Hand someHand = new Hand(cards);
                PokerHandsChecker checker = new PokerHandsChecker();
                Assert.AreEqual(true, checker.IsFlush(someHand));
            }
        }

        [TestMethod]
        public void IsFlushShouldBeFalseIfOneCardsDiffers()
        {
            for (int i = 1; i <= 4; i++)
            {
                List<ICard> cards = new List<ICard>();
                cards.Add(new Card(CardFace.Jack, (CardSuit)i));
                cards.Add(new Card(CardFace.Eight, (CardSuit)i));
                cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
                cards.Add(new Card(CardFace.Six, (CardSuit)i));
                cards.Add(new Card(CardFace.Three, (CardSuit)i));
                Hand someHand = new Hand(cards);
                PokerHandsChecker checker = new PokerHandsChecker();
                if ((CardSuit)i != CardSuit.Hearts)
                {
                    Assert.AreEqual(false, checker.IsFlush(someHand));
                }
                else
                {
                    Assert.AreEqual(true, checker.IsFlush(someHand));
                }   
            }
        }

        [TestMethod]
        public void IsFourOfAKindIsValidOnlyIfTheHandIsValid()
        {
            List<ICard> cards = new List<ICard>();
            for (int i = 0; i < 3; i++)
            {
                cards.Add(new Card((CardFace)i + 1, CardSuit.Diamonds));
            }

            Hand someHand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(false, checker.IsFourOfAKind(someHand));
        }

        [TestMethod]
        public void IsFourOfAKindIsValidOnlyIfThereAreFourCardsOfOneFacde()
        {
            Random generator = new Random();
            for (int i = 2; i <= 14; i++)
            {
                List<ICard> cards = new List<ICard>();
                cards.Add(new Card((CardFace)i, (CardSuit)generator.Next(1, 4)));
                cards.Add(new Card((CardFace)i, (CardSuit)generator.Next(1, 4)));
                cards.Add(new Card((CardFace)i, (CardSuit)generator.Next(1, 4)));
                cards.Add(new Card((CardFace)i, (CardSuit)generator.Next(1, 4)));
                cards.Add(new Card(CardFace.Three, (CardSuit)i));
                Hand someHand = new Hand(cards);
                PokerHandsChecker checker = new PokerHandsChecker();
                Assert.AreEqual(false, checker.IsFlush(someHand));
            }
        }

        public void IsFourOfAKindIsNotValidIfThereAreNotFourCardsOfOneFace()
        {
            Random generator = new Random();
            for (int i = 2; i <= 14; i++)
            {
                List<ICard> cards = new List<ICard>();
                cards.Add(new Card((CardFace)i, (CardSuit)generator.Next(1, 4)));
                cards.Add(new Card((CardFace)i, (CardSuit)generator.Next(1, 4)));
                cards.Add(new Card((CardFace)i, (CardSuit)generator.Next(1, 4)));
                cards.Add(new Card(CardFace.Three, (CardSuit)generator.Next(1, 4)));
                cards.Add(new Card(CardFace.Three, (CardSuit)i));
                Hand someHand = new Hand(cards);
                PokerHandsChecker checker = new PokerHandsChecker();
                if (someHand.Cards[4].Face != CardFace.Three)
                {
                    Assert.AreEqual(false, checker.IsFourOfAKind(someHand));
                }
                else
                {
                    Assert.AreEqual(true, checker.IsFourOfAKind(someHand));
                }
            }
        }
    }
}
