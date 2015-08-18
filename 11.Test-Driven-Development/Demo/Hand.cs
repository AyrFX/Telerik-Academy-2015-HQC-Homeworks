namespace Poker
{
    using System;
    using System.Collections.Generic;

    public class Hand : IHand
    {
        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public IList<ICard> Cards { get; private set; }

        public override string ToString()
        {
            string result = string.Empty;
            for (int i = 0; i < this.Cards.Count; i++)
            {
                if (result != string.Empty)
                {
                    result += ", ";
                }

                result += this.Cards[i].ToString();
            }

            return result;
        }
    }
}
