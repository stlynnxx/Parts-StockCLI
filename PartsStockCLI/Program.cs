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
                
                
                
                
                Menu menu = new Menu();
                Submit sub = new Submit();
                Nums nums = new Nums();
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
                        search.DeMenu();
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

        class Submit
        {
            private static string[] itemData;

            public static void Submission()
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "items.json");
                if (path == null)
                {
                    File.Create(path).Close();
                }
                else
                {
                    string nameTag = "Item name: ";
                    string descriptionTag = "Item description: ";
                    string storageTag = "Storage Location: ";
                    string purchaseTag = "Purchase Price: ";
                    string soldTag = "Sold? (Y|N)";
                    bool soldBool = false;
                    string ssoldBool = "";
                    Console.WriteLine(nameTag);
                    string itemName = Console.ReadLine();
                    Console.WriteLine(descriptionTag);
                    string itemScript = Console.ReadLine();
                    Console.WriteLine(storageTag);
                    string itemStorage = Console.ReadLine();
                    Console.WriteLine(purchaseTag);
                    string purchasePrice = Console.ReadLine();
                    Console.WriteLine(soldTag);
                    string soldAns = Console.ReadLine();
                    string upAns = soldAns.ToUpper();
                    string soldPrice = "";
                    
                    if (upAns == "Y")
                    { 
                        soldBool = true;
                        ssoldBool = "SOLD";
                        
                        
                    }
                    else
                    {
                        soldBool = false;
                        ssoldBool = "Unsold";
                    }

                    Dictionary<int, string> itemData =  new Dictionary<int, string>();
                    itemData.Add(0, itemName);
                    itemData.Add(1, itemScript);
                    itemData.Add(2, itemStorage);
                    itemData.Add(3, purchasePrice);
                    itemData.Add(4, ssoldBool);
                    // string addr = $"itemName ={itemName};itemScript={itemScript};itemStorage={itemStorage};";
                    string addrOne = $"Item Name: {itemName}";
                    string addrTwo = $"Description: {itemScript}";
                    string addrThree = $"Storage Location: {itemStorage}";
                    string addrFour = $"Purchase Price: {purchasePrice}";
                    string addrFive = $"Sold?: {ssoldBool}";
                    if (upAns == "Y")
                    {
                        Console.WriteLine("Sold Price: ");
                        soldPrice =  Console.ReadLine();
                    }
                    else
                    {
                        soldPrice = "Unsold";

                    }

                    string addrSix = $"Sold Price:  {soldPrice}";

                    string jsonOne = JsonSerializer.Serialize(addrOne);
                    string jsonTwo = JsonSerializer.Serialize(addrTwo);
                    string jsonThree = JsonSerializer.Serialize(addrThree);
                    string jsonFour = JsonSerializer.Serialize(addrFour);
                    string jsonFive = JsonSerializer.Serialize(addrFive);
                    string jsonSix = JsonSerializer.Serialize(addrSix);
                    string[] jsonAppends = {jsonOne, jsonTwo, jsonThree, jsonFour, jsonFive, jsonSix};
                    File.AppendAllLines(path, jsonAppends);
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

