using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sorteper.Classes;

namespace Sorteper
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initializes the main game class. This is used to run the entire game. Making it not dependant on the gui type.
            Game game = new OldMaidGame();
            Console.WriteLine("Game name: " + game.GameName);

            Console.Write("Write your name: ");
            string playerName = Console.ReadLine();

            //Adding a human player from the user input.
            game.AddHumanPlayer(playerName);
            game.DealCards(); //Dealing cards.

            Console.WriteLine();
            Console.WriteLine("____________________________");
            Console.WriteLine();
            Console.WriteLine("The cards has now been delt.");
            Console.WriteLine("____________________________");
            Console.WriteLine();

            //Displays the removed duplicates from the user's and CPU-player's hand.  
            foreach (string duplicate in game.HumanPlayer.RemoveDuplicates())
            {
                Console.WriteLine("Removed a pair of " + duplicate + " from your hand!");
            }
            Console.WriteLine("____________________________");
            foreach (string duplicate in game.CPU.RemoveDuplicates())
            {
                Console.WriteLine("Removed a pair of " + duplicate + " from your opponents hand!");
            }
            Console.WriteLine("____________________________");
            Console.ReadKey();

            do
            {
                Console.Clear();
                Console.WriteLine("Current turn: " + game.HumanPlayer.PlayerName);
                Console.WriteLine("____________________________");
                Console.WriteLine("Your hand:");
                foreach (Card card in game.HumanPlayer.Hand)
                {
                    Console.WriteLine(card.CardName); //Displays the player's current hand.
                }
                string playerWithOldMaidMessage;
                if (game.HumanPlayer.HasOldMaid())
                {
                    playerWithOldMaidMessage = "------You have the Old Maid!------";
                }
                else
                {
                    playerWithOldMaidMessage = "------Your opponent have the Old Maid!------";
                }
                Console.WriteLine("____________________________");
                Console.WriteLine();
                //Displays a message with information about who has the Old Maid card.
                Console.WriteLine(playerWithOldMaidMessage); 
                Console.WriteLine("____________________________");
                Console.WriteLine();
                Console.WriteLine("____________________________");
                Console.WriteLine();
                Console.WriteLine("Your options:");
                Console.WriteLine();
                Console.WriteLine("1. Take card from opponents hand.");
                Console.WriteLine("2. Shuffle your hand.");
                Console.WriteLine("____________________________");

                //Switch case of the main menu options per turn.
                switch (GetMenuInput(1, 2))
                {
                    case 1:
                        //1. Take card from opponents hand.
                        Console.WriteLine();
                        Console.WriteLine("____________________________");
                        //Displays menu of all the cards in the CPU player's hand. 
                        //This allows the player to take a card from the opponents hand.
                        for (int i = 0; i < game.CPU.Hand.Count; i++)
                        {
                            Console.WriteLine(i + ". Take card number:" + i);
                        }

                        byte choice = GetMenuInput(0, game.CPU.Hand.Count - 1);
                        string cardName = game.HumanPlayer.TakeCard(game.CPU, choice).CardName;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("____________________________");
                        Console.WriteLine("You have taken " + cardName + " from your opponent!");
                        Console.WriteLine();

                        //Removes duplicates from the players hand, after a new ccard has been taken.
                        foreach (string duplicate in game.HumanPlayer.RemoveDuplicates())
                        {
                            Console.WriteLine("Removed a pair of " + duplicate + " from your hand!");
                        }
                        Console.WriteLine("____________________________");

                        Console.ReadKey();

                        //PC takes a turn.
                        Console.WriteLine();
                        Console.WriteLine("____________________________");
                        Console.WriteLine(game.TakeCPUTurn()); //Lets the PC take a turn.
                        Console.WriteLine("");
                        foreach (string duplicate in game.CPU.RemoveDuplicates())
                        {
                            Console.WriteLine("Removed a pair of " + duplicate + " from your opponents hand!");
                        }
                        Console.WriteLine("____________________________");                   
                        Console.ReadKey();

                        break;
                    case 2:
                        //2. Shuffle your hand.
                        //Allows the player to shuffle their hand. This does not take a turn.
                        game.HumanPlayer.ShuffleHand();
                        Console.WriteLine();
                        Console.WriteLine("____________________________");
                        Console.WriteLine("Your hand has been shuffled!");
                        Console.WriteLine("____________________________");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }

            } while (game.NewRound());

            Console.Clear();
            Console.WriteLine("____________________________");
            Console.WriteLine();
            Console.WriteLine(game.EndingMessage());
            Console.WriteLine("____________________________");
            Console.ReadKey();
        }
        
        //Simple menu validater class. GUI specifik.
        static byte GetMenuInput(int start, int end)
        {
            bool menuError = false;
            byte menuChoise = 0;
            do
            {
                ConsoleKeyInfo userInput = Console.ReadKey();
                if (char.IsDigit(userInput.KeyChar))
                {
                    menuChoise = byte.Parse(userInput.KeyChar.ToString());
                    if (menuChoise >= start && menuChoise <= end)
                    {
                        menuError = false;
                    }
                    else
                    {
                        menuError = true;
                    }
                }
                else
                {
                    menuError = true;
                }

                if (menuError)
                {
                    //Error handling.
                    Console.WriteLine();
                    Console.WriteLine("_______________________");
                    Console.WriteLine("Not a valid menu input.");
                    Console.Write("Please try again:");
                }
            } while (menuError);
            return menuChoise;
        }   
    }
}
