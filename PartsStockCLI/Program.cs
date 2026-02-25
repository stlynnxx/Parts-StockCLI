using System;
using System.IO;
using System.Security.Cryptography;


namespace PartsStockCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Route r = new Route();
            Display display = new Display();
            Display.Art();
            Route.Routed();

        }

        public class Display
        {
            public static void Art()
            {
                string art =
                    "__________                __           ____     _________ __                 __    \n\\______   \\_____ ________/  |_  ______/  _ \\   /   _____//  |_  ____   ____ |  | __\n |     ___/\\__  \\\\_  __ \\   __\\/  ___/>  _ </\\ \\_____  \\\\   __\\/  _ \\_/ ___\\|  |/ /\n |    |     / __ \\|  | \\/|  |  \\___ \\/  <_\\ \\/ /        \\|  | (  <_> )  \\___|    < \n |____|    (____  /__|   |__| /____  >_____\\ \\/_______  /|__|  \\____/ \\___  >__|_ \\\n                \\/                 \\/       \\/        \\/                  \\/     \\/\n";
                Console.WriteLine(art);

            }
        }

        public class Menu
        {
            public static int Home()
            {
                Console.WriteLine("-------------------------\n" +
                                  "1) New Entry\n" +
                                  "2) Search\n" +
                                  "3) Stats\n" +
                                  "4) Exit\n" +
                                  "------------------------");
                int userInput = Convert.ToInt32(Console.ReadLine());
                return userInput;
            }
        }

        class Route
        {
            public static void Routed()
            {
                Menu menu = new Menu();
                Submit sub = new Submit();
                Nums nums = new Nums();
                
               
                int userIn = Menu.Home();
                switch (userIn)
                {
                    case 1:
                        Submit.Submission();
                        break;
                    case 2:
                        Console.WriteLine("You chose two");
                        Submit.Search();
                        break;
                    case 3:
                        Console.WriteLine("You chose three");
                        Nums.Stats();

                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Switch default error");
                        break;

                }
            }
        }

        class Submit
        {
            private static string[] itemData;

            public static void Submission()
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "items.txt");
                if (File.Exists(path) == false)
                {
                    File.Create(path).Close();
                }
                

                Console.WriteLine("Item name:");
                    string itemName = Console.ReadLine();
                    Console.WriteLine("Description:");
                    string itemScript = Console.ReadLine();
                    Console.WriteLine("Storage Location:");
                    string itemStorage = Console.ReadLine();
                    itemData = new string[] { itemName, itemScript, itemStorage };
                    File.AppendAllLines(path, itemData);
            }

            public static void Search()
            {
                Console.WriteLine("Search Term: ");
                string searchTerm = Console.ReadLine();
                string searchFor = itemData[0];
                if (searchTerm == searchFor)
                {
                    Console.WriteLine("Item: itemData[0]");
                }
                else
                {
                    Console.WriteLine("Item not found!");
                }



            }

           

        }
        public class Nums
        {
            public static void Stats()
            {
                Console.WriteLine("Stats!");
            }
        }

    }

}

