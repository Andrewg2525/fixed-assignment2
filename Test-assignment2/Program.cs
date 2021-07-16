using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestAssignment2
{
    class Program
    {

        private static Dictionary<int, string> guests = new Dictionary<int, string>();
        private static int min = 1000;
        private static int max = 9999;
        private static int raffleNumber;
        private static Random _rdm = new Random();
        private static string participant;
        private static string nameToAdd;

        //method 1
        private static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string name = Console.ReadLine();
            return name;
        }


        // method 2
        //private static void GetUserInfo()
        //{

        //    string moreName;

        //    do
        //    {
        //        participant = GetUserInput("Please enter participant name.");
        //        moreName = GetUserInput("Do you want to add any other participants?").ToLower();
        //        nameToAdd = participant;
        //        raffleNumber = GenerateRandomNumber();
        //        AddGuestsInRaffle(raffleNumber, nameToAdd);
        //    }
        //    while (moreName == "yes");

        private static void GetUserInfo()
        {

            string moreName;

            do
            {
                participant = GetUserInput("Please enter participant name.");
                moreName = GetUserInput("Do you want to add any other participants?").ToLower();
                nameToAdd = participant;
                int raffleNumber = GenerateRandomNumber(min, max);
                AddGuestsInRaffle(raffleNumber, nameToAdd);
            }
            while (moreName == "yes");


        }
        //method 3
        private static int GenerateRandomNumber(int min, int max)
        {
            return _rdm.Next(min, max);
        }

        //method 4
        private static void AddGuestsInRaffle(int raffleNumber, string nameToAdd)
        {
            guests.Add(raffleNumber, nameToAdd);
        }

        //method 5
        private static void PrintGuestsName()
        {
            Console.WriteLine("test");
            foreach (var numAndName in guests)
            {
                Console.WriteLine($"{numAndName.Value} : {numAndName.Key}");
            }
            Console.WriteLine();
        }

        //method 6
        private static int GetRaffleNumber(Dictionary<int, string> guests)
        {
            List<int> keyList = guests.Keys.ToList();

            //Random rand = new Random();
            int randomKey = _rdm.Next(keyList.Count);
            int winnerNumber = keyList[randomKey];
            return winnerNumber;

        }

        private static void PrintWinner()
        {
            int winnerNumber = GetRaffleNumber(guests);
            string winnerName = guests[winnerNumber];
            Console.WriteLine($"The Winner is : {winnerName} with the # {winnerNumber}");
            /*foreach (var numAndName in guests)
                if (winnerNumber == numAndName.Key)
                {
                    string winnerName = numAndName.Value;
                    Console.WriteLine(numAndName.Key);
                    //Console.WriteLine($"The Winner is : {winnerName} with the # {winnerNumber}");
                }
                else
                {
                    Console.WriteLine("Garcia, your shit broke here");
                }*/

        }


        //method 7
        /*   private static void PrintWinner()
           {
               int winnerNumber = GetRaffleNumber();

               foreach (var kvp in guests)
                   if (winnerNumber == kvp.Key)
                   {
                       string winnerName = kvp.Value;
                       Console.WriteLine(kvp.Key);
                       //Console.WriteLine($"The Winner is : {winnerName} with the # {winnerNumber}");
                   }
                   else
                   {
                       Console.WriteLine("Garcia, your shit broke here");
                   }

           }
        */


        // I think the hold up is the inputs are not saving properly to the dictionary.

        private static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the raffle to decide if you pass LaunchCode!");
            GetUserInfo();
            PrintGuestsName();
            Thread.Sleep(3000);
            MultiLineAnimation();
            PrintWinner();
        }



        //Start writing your code here






        static void MultiLineAnimation() // Credit: https://www.michalbialecki.com/2018/05/25/how-to-make-you-console-app-look-cool/
        {
            var counter = 0;
            for (int i = 0; i < 30; i++)
            {
                Console.Clear();

                switch (counter % 4)
                {
                    case 0:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    │││ \\   ║");
                            Console.WriteLine("         ║    │││  O  ║");
                            Console.WriteLine("         ║    OOO     ║");
                            break;
                        };
                    case 1:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                    case 2:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║   / │││    ║");
                            Console.WriteLine("         ║  O  │││    ║");
                            Console.WriteLine("         ║     OOO    ║");
                            break;
                        };
                    case 3:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                }

                counter++;
                Thread.Sleep(200);
            }
        }
    }
}
