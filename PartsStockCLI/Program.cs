using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace PartsStockCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Route r = new Route();
            Display display = new Display();
            Display.Art();
            r.Routed();

        }

        public class Display
        {
            public static void Art()
            {
                
                
                Console.Title = "Parts Stock CLI";
                Console.ForegroundColor = ConsoleColor.Green;
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
                                  "1) New Item\n" +
                                  "2) Item Search\n" +
                                  "3) Sourcing\n" +
                                  "4) Storage Location Setup\n" +
                                  "5) Exit\n" +
                                  "Dev Options: \n" +
                                  "6) Delete File\n" +
                                  "7) Overwrite File\n" +
                                  "------------------------");
                int userInput = Convert.ToInt32(Console.ReadLine());
                return userInput;
            }
        }

        class Route
        {

            public string Pather(string fileName)
            {
               
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    fileName);

                return path;
            }

            public void Routed()
            {
                StorageLocations storageLocations = new StorageLocations();
                AddItem add = new AddItem();
                Sourcing sourcing = new Sourcing();
                ItemSearch search = new ItemSearch();
                
               
                int userIn = Menu.Home();
                switch (userIn)
                {
                    case 1:
                        add.NewItem();
                        break;
                    case 2:
                        Console.WriteLine("You chose two");
                        search.Menu();
                        break;
                    case 3:
                        sourcing.Main();
                        break;
                    case 4:
                        storageLocations.StorageMain();
                        break;
                    case 5:
                        
                        break;
                    
                        case 6:
                            File.Delete("Items.json");
                            break;
                        
                           case 7:
                         
                            Console.WriteLine("Filename to be overwritten");
                            string userInput = Console.ReadLine();
                            string path = Pather("ItemList.json");
                            File.WriteAllText(path, "         ");
                            break;
                                    
                            default:
                            Console.WriteLine("Switch default error");
                        break;

                }
            }
        }

        }

    }



