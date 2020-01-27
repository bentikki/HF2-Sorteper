using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteper.Classes
{
    class Card
    {
        private byte cardValue;
        private string suit;

        public string CardName { get { return this.cardValue + " of " + this.suit; }  }
        public byte CardValue { get { return this.cardValue; } }
        public string Suit { get { return this.suit; } }

        public Card(byte cardValue, string suit)
        {
            this.suit = suit;
            this.cardValue = cardValue;
        }
    }
}
