using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteper.Classes
{
    class Deck
    {
        private List<Card> cardsInDeck;
        protected List<string> suits;
        protected byte CardValues;

        public byte NumberOfCardsInDeck { get { return Convert.ToByte(this.cardsInDeck.Count); }  }
        public List<Card> GetDeck { get { return this.cardsInDeck; }  }
        public byte GetCardValues { get { return this.CardValues; } }

        protected void CreateDeck()
        {
            cardsInDeck = new List<Card>();
            foreach (var suit in this.suits)
            {
                for (byte cardValue = 1; cardValue <= CardValues; cardValue++)
                {
                    cardsInDeck.Add(new Card(cardValue, suit));
                }
            }
        }

        protected void AddCard(byte cardValue, string suit)
        {
            this.cardsInDeck.Add(new Card(cardValue, suit));
        }

        protected void Shuffle()
        {
            Random rand = new Random();
            this.cardsInDeck = this.cardsInDeck.OrderBy(x => rand.Next()).ToList();
        }

        public Card GiveCard()
        {
            Random random = new Random();
            int index = random.Next(this.cardsInDeck.Count);
            Card chosenCard = this.cardsInDeck[index];
            this.cardsInDeck.RemoveAt(index);
            return chosenCard;
        }
    }
}
