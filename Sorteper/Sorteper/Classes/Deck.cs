using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteper.Classes
{
    class Deck
    {
        //Private and protected attributes. 
        private List<Card> cardsInDeck; //Holds the Card objects in the deck.
        protected List<string> suits; //This is set in the child object.
        protected byte CardValues; //This is set in the child object.

        public byte NumberOfCardsInDeck { get { return Convert.ToByte(this.cardsInDeck.Count); }  }
        public List<Card> GetDeck { get { return this.cardsInDeck; }  }
        public byte GetCardValues { get { return this.CardValues; } }

        //Method to create a deck of cards.
        //This takes the suits and CardValues attributes, and creates a deck based on these parameters.
        protected void CreateDeck()
        {
            cardsInDeck = new List<Card>();

            //Goes through the entries in the suits string list, 
            //and creates a new card for each value in the CardValue attribute.
            foreach (var suit in this.suits)
            {
                for (byte cardValue = 1; cardValue <= CardValues; cardValue++)
                {
                    cardsInDeck.Add(new Card(cardValue, suit));
                }
            }
        }

        //Simple method to add a card to the current deck. 
        protected void AddCard(byte cardValue, string suit)
        {
            this.cardsInDeck.Add(new Card(cardValue, suit));
        }

        //Shuffle function. Shuffles the current deck. 
        protected void Shuffle()
        {
            Random rand = new Random();
            //Lambda expression to shuffle the deck.
            //Does so by creating a Random object, 
            //ordering the List of cards based on this Random,
            //and herafter setting the cardsInDeck attribute to this new list.
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
