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

            Game game = new OldMaidGame();
            Console.WriteLine("Game name: " + game.GameName);

            Console.Write("Write your name: ");
            string playerName = Console.ReadLine();

            game.AddHumanPlayer(playerName);
            game.DealCards();

            Console.WriteLine();
            Console.WriteLine("____________________________");
            Console.WriteLine();
            Console.WriteLine("The cards has now been delt.");
            Console.WriteLine("____________________________");
            Console.WriteLine();

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
                    Console.WriteLine(card.CardName);
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

                switch (GetMenuInput(1, 2))
                {
                    case 1:
                        //1. Take card from opponents hand.
                        Console.WriteLine();
                        Console.WriteLine("____________________________");
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

                        foreach (string duplicate in game.HumanPlayer.RemoveDuplicates())
                        {
                            Console.WriteLine("Removed a pair of " + duplicate + " from your hand!");
                        }
                        Console.WriteLine("____________________________");

                        Console.ReadKey();

                        //PC takes a turn.
                        Console.WriteLine();
                        Console.WriteLine("____________________________");
                        Console.WriteLine(game.TakeCPUTurn());
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
