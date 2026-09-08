using System.Security.Cryptography;
using System.Text.Json;
using PartsStockCLI;
namespace PartsStockCLI;

public class AddItem
{
    public void NewItem(string directory, string path, string storagePath)
    {
        Console.Clear();
        /* caller() collects the input for the new item fields and
         assigns them, appender appends them*/
        Item newItem = new Item();
        caller(newItem, path);
        void appender(Item item)
        {
            bool isNewFile = false;
            if (!File.Exists(path))
            {
                Console.WriteLine("path null");
                File.Create(path).Close();
                File.WriteAllText(path, "[]");
                isNewFile = true;
                // File.AppendAllText(path, JsonSerializer.Serialize("{ Items: {"))
            }
            else
            {
                // Console.WriteLine("path already exists");
            }
            if (isNewFile == true)
            {
                item.ItemNumber = 1;
            }
            if (isNewFile == false)
            {

                using JsonDocument doc = JsonDocument.Parse(File.ReadAllText(path));
                int count = doc.RootElement.GetArrayLength();
                item.ItemNumber = count + 1;
            }
            List<string> appends = new List<string>();
            appends.Add($"[Item Name: {item.ItemName}");
            appends.Add($"Item Number: {item.ItemNumber}");
            appends.Add($"Item Description:  {item.ItemDescription}");
            appends.Add($"Item Price: {item.ItemPrice}");
            appends.Add($"Item Quantity: {item.ItemQuantity}");
            appends.Add($"Item PurchaseDate: {item.ItemPurchaseDate}");
            Console.WriteLine("Would you like to add a storage location for this item? (y/n)");
            string storageQuestion = Console.ReadLine();
            storageQuestion = storageQuestion.ToLower();
            bool confirm = false;
            int timeout = 0;
            if (storageQuestion == "y")
            {
                while (confirm == false)
                {
                    StorageLocations.NameSearch search = new StorageLocations.NameSearch(storagePath);
                    search.search();
                    Console.WriteLine("Is the shown location correct? (y/n)");
                    string confirmStr = Console.ReadLine().ToLower();
                    if (confirmStr == "y" || timeout == 2)
                    {
                        confirm = true;
                    }
                    timeout++;
                } // End of while
                Console.WriteLine("--------");
                appender(item);
            }
            appends.Add("]\\n");
            var options = new JsonSerializerOptions { WriteIndented = true };
            List<Item> items = JsonSerializer.Deserialize<List<Item>>(File.ReadAllText(path));
            items.Add(item);
            File.WriteAllText(path, JsonSerializer.Serialize(items, options));
            Console.WriteLine("Item Added!");
            Program.displayBool = false;
            Program.Main();
        }
        void caller(Item item, string storagePath)
        {
            bool confirm = false;
            string confirmStr;
            int timeout = 0;
            Console.WriteLine("--------");
            Console.WriteLine("Item Name: ");
            item.ItemName = Console.ReadLine();
            Console.WriteLine("Item Description: ");
            item.ItemDescription = Console.ReadLine();
            Console.WriteLine("Item Price: NUMS ONLY ");
            item.ItemPrice = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Item Quantity: NUMS ONLY ");
            item.ItemStock = int.Parse(Console.ReadLine());
            Console.WriteLine("Item PurchaseDate: ");
            item.ItemPurchaseDate = Console.ReadLine();
            Console.WriteLine("Would you like to use a saved Storage Location for this item? (y/n)");
            string storeQuestion = Console.ReadLine();
            storeQuestion = storeQuestion.ToLower();
            if (storeQuestion == "y")
            {
                // This is where we will need to put the logic for associating a saved storage location
                // We will need to search the storage locations, find the match, confirm, and then associate.
                while (confirm == false)
                {
                    StorageLocations.NameSearch search = new StorageLocations.NameSearch(storagePath);
                    search.search();
                    Console.WriteLine("Is the shown location correct? (y/n)");
                    confirmStr = Console.ReadLine().ToLower();
                    if (confirmStr == "y" || timeout == 2)
                    {
                        confirm = true;
                    }

                    timeout++;
                } // End of while

                Console.WriteLine("--------");
                appender(item);
            }
        }
    }



    public class Item
    {
        private string itemName;
        private int itemNumber;
        private string itemDescription;
        private decimal itemPrice;
        private int itemQuantity;
        private int itemStock;
        private string itemPurchaseDate;
        private StorageLocations storageLocation;
        private Sourcing sourceLocation;

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        public int ItemNumber
        {
            get { return itemNumber; }
            set { itemNumber = value; }
        }

        public string ItemDescription
        {
            get { return itemDescription; }
            set { itemDescription = value; }
        }

        public decimal ItemPrice
        {
            get { return itemPrice; }
            set { itemPrice = value; }
        }

        public int ItemQuantity
        {
            get { return itemQuantity; }
            set { itemQuantity = value; }
        }

        public int ItemStock
        {
            get { return itemStock; }
            set { itemStock = value; }
        }

        public string ItemPurchaseDate
        {
            get { return itemPurchaseDate; }
            set { itemPurchaseDate = value; }
        }

        public StorageLocations StorageLocation
        {
            get { return storageLocation; }
            set { storageLocation = value; }
        }
        
        public Sourcing SourceLocation
        {
            get { return sourceLocation; }
            set { sourceLocation = value; }
        }
    }
    
}
