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
            this.suits = new List<string> { "Monkeys", "Cats", "Cows", "Sparrows", "Lions", "Dolphins", "Dogs", "Whales", "Horses", "Snakes", "Sheeps", "Snails", "Lizards", "Turtles" };
            this.CardValues = 2;

            this.CreateDeck();
            this.AddCard(0, "Old Maid / Sorteper");
            this.Shuffle();
        }

    }
}
