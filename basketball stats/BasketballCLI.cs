using basketball_stats.DAO;
using System;
using System.Collections.Generic;
using System.Text;


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

                }


                if (selection == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Goodbye!");
                    running = false;
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

   
