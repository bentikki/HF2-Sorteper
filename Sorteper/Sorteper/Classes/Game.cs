using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteper.Classes
{
    class Game
    {
        protected string gameName;
        protected Deck deck;
        private List<Player> playerList = new List<Player>();
        private Player humanPlayer;
        private Player cpu;
        private Player losingPlayer;

        public string GameName { get { return this.gameName; } }
        public Deck Deck{ get { return this.deck; } }
        public List<Player> Players { get { return this.playerList; } }
        public Player HumanPlayer { get { return this.humanPlayer; } }
        public Player CPU { get { return this.cpu; } }

        //Constructor for the game object. Creates a PC-player.
        public Game()
        {
            Player cpuPlayer = new Player("CPU");
            this.playerList.Add(cpuPlayer);
            this.cpu = cpuPlayer;
        }

        //Method to add a human player. Takes a string parameter. 
        public void AddHumanPlayer(string playerName)
        {
            Player player = new Player(playerName + "-Player", true);
            this.playerList.Add(player);
            this.humanPlayer = player;
        }

        //Method to deal cards to the players. 
        //Uses the deck.
        public void DealCards()
        {
            while (this.deck.NumberOfCardsInDeck > 0)
            {
                foreach (Player player in this.playerList)
                {
                    if (this.deck.NumberOfCardsInDeck > 0)
                    {
                        player.AddCardToHand(deck.GiveCard());
                    }
                }
            }
        }

        //Method for the CPU player to take a turn.
        //Simply takes a random card from your hand and shuffles it owns hand.
        //Returns a string containing the message of what happened on the CPU players turn.
        public string TakeCPUTurn()
        {
            if (this.NewRound())
            {
                Random rnd = new Random();
                int rndNumber = rnd.Next(0, this.HumanPlayer.Hand.Count - 1);
                Card takenCard = this.CPU.TakeCard(this.HumanPlayer, Convert.ToByte(rndNumber));
                this.CPU.ShuffleHand();
                return "CPU has taken your " + takenCard.CardName + "!";
            }
            else
            {
                return "CPU is out of cards!";

            }

        }
        public bool NewRound()
        {
            bool continueBool = true;
            foreach (Player player in this.playerList)
            {
                if(player.Hand.Count == 1)
                {
                    if(player.Hand.First().CardValue == 0)
                    {
                        continueBool = false;
                        this.losingPlayer = player;
                    }
                }
                else if (player.Hand.Count <= 0)
                {
                    if(player.PlayerName == this.CPU.PlayerName)
                    {
                        this.losingPlayer = this.HumanPlayer;
                    }
                    else if (player.PlayerName == this.HumanPlayer.PlayerName)
                    {
                        this.losingPlayer = this.CPU;
                    }

                }
            }
            return continueBool;
        }

        public string EndingMessage()
        {
            return "Game over! The loser was: " + losingPlayer.PlayerName; 
        }

    }
}
