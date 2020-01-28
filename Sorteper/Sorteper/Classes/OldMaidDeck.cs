using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteper.Classes
{
    class OldMaidDeck : Deck
    {
        public OldMaidDeck()
        {
            //Sets the suits.
            this.suits = new List<string> { "Monkeys", "Cats", "Cows", "Sparrows", "Lions", "Dolphins", "Dogs", "Horses", "Snakes", "Snails", "Lizards", "Turtles" };
            //Sets the number of values cards are allowed to have. Sat to 2, means that 2 cards of each type will be made. 
            this.CardValues = 2;

            this.CreateDeck();
            this.AddCard(0, "Old Maid / Sorteper");
            this.Shuffle();
        }

    }
}
