using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteper.Classes
{
    class Card
    {
        //Private attributes. 
        private byte cardValue;
        private string suit;

        //Public properties, with only get functionality. 
        public string CardName { get { return this.cardValue + " of " + this.suit; }  }
        public byte CardValue { get { return this.cardValue; } }
        public string Suit { get { return this.suit; } }
        
        //Card constructor. Takes a value and a suit.
        //This could eg. be 4 of Hearts, King of Diamands, or 1 of Cats. 
        public Card(byte cardValue, string suit)
        {
            this.suit = suit;
            this.cardValue = cardValue;
        }
    }
}
