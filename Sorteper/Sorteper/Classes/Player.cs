﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteper.Classes
{
    class Player
    {
        private string playerName;
        private bool humanPlayer;
        private List<Card> handOfCards = new List<Card>();

        public string PlayerName { get { return this.playerName; } }
        public List<Card> Hand { get { return this.handOfCards; } }

        public Player(string playerName)
        {
            this.playerName = playerName;
        }
        public Player(string playerName, bool humanPlayer) : this(playerName)
        {
            this.humanPlayer = humanPlayer;
        }
        public void AddCardToHand(Card card)
        {
            this.handOfCards.Add(card);
        }

        public void ShuffleHand()
        {
            Random rand = new Random();
            this.handOfCards = this.handOfCards.OrderBy(x => rand.Next()).ToList();
        }

        public Card GiveCard(byte cardPos)
        {
            try
            {
                Card chosenCard = this.handOfCards[cardPos];
                this.handOfCards.RemoveAt(cardPos);
                return chosenCard;
            }
            catch (Exception)
            {
                return null;
                
            }
        }

        public Card TakeCard(Player opponent, byte cardNumber)
        {
            Card addedCard = opponent.GiveCard(cardNumber);
            this.AddCardToHand(addedCard);
            return addedCard;
        }
        public List<string> RemoveDuplicates()
        {
            List<string> removedList = new List<string>();
            for (int i = 0; i < this.handOfCards.Count; i++)
            {
                List<Card> dupList = this.handOfCards.Where(p => p.Suit == this.Hand[i].Suit).ToList();
                if( dupList.Count >= 2)
                {
                    removedList.Add(this.handOfCards[i].Suit);
                    this.handOfCards = this.handOfCards.Except(dupList).ToList();
                }
            }
            return removedList;
        }

    }
}
