using basketball_stats.DAO;
using basketball_stats.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace basketball_stats
{
    class BasketballCLI
    {
        private readonly IBasketballDAO basketballDao;


        public BasketballCLI(IBasketballDAO basketballDao)
        {
            this.basketballDao = basketballDao;
        }

        public void RunCLI()
        {
            DisplayBanner();

            bool running = true;

            while (running)
            {
                DisplayMenu();
                int selection = PromptForInt("Please select an option: ");


                if (selection == 1)
                {
                    PromptForNameAndDisplayPlayerList();

                }


                if (selection == 2)
                {
                    Console.Clear();
                    Thread.Sleep(1000);
                    Console.WriteLine("Goodbye!");
                    // By making running false, we close the program
                    running = false;
                }
             
            }

        }

        public void GettingPlayerInfo()
        {
            PromptForNameAndDisplayPlayerList();

        }

        //TO DO: split this method up (PromptForName & DisplayPlayerList)
        private IList<Player> PromptForNameAndDisplayPlayerList()
        {
            while (true)
            {
                Console.WriteLine("Please enter any part of a player's name: ");
                string response = Console.ReadLine();


                // Before, if user puts in nothing and hits enter, program  lists out every player. Don't want that...
                if (response == "")
                {
                    Console.WriteLine("You didn't put in anything. Try again");
                    continue;
                }

                IList<Player> playerList = basketballDao.GetPlayer(response);

                
                if (playerList.Count == 0)
                {
                    Console.WriteLine("Woops, there are no players by that name!");
                }
                for (int i = 0; i < playerList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) - Name: {playerList[i].PlayerName}, Points: {playerList[i].Points}");
                }

            }
        }


        private void DisplayBanner()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("| Welcome to The Basketball Database |");
            Console.WriteLine("--------------------------------------");

        }


        private void DisplayMenu()
        {
            Console.WriteLine("1. View Player Info");
            Console.WriteLine("2. Exit");
        }


        private int PromptForInt(string input)
        {
            // Just casts the decimal return value to an integer
            return (int)PromptForDecimal(input);
        }

        private decimal PromptForDecimal(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string response = Console.ReadLine();

                // TryParse = makes sure user input can be parsed to a decimal 
                if (decimal.TryParse(response, out decimal parsedDecimal))
                {
                    return parsedDecimal;
                }

                // So if user input can't be converted to decimal...
                else
                {
                    if (string.IsNullOrWhiteSpace(response))
                    {
                        // "Assumes negative numbers are never valid entries"(??)"
                        return -1;
                    }
                    else
                    {
                        Console.WriteLine("Thats not a number! Try again.");
                    }
                }

            }

        }



    }
}

   
