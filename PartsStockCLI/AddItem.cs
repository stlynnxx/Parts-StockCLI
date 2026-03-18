using System.Text.Json;

namespace PartsStockCLI;

public class AddItem
{
    public void NewItem()
    {
        Console.Clear();
        /* caller() collects the input for the new item fields and
         assigns them, appender appends them*/
        Item newItem = new Item();
        caller(newItem);

        void appender(Item item)
        {
            bool isNewFile = false;
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "ItemList.json");
            if (!File.Exists(path))
            {
                Console.WriteLine("path null");
                File.Create(path).Close();
                File.WriteAllText(path, "[]");
                isNewFile = true;
                // File.AppendAllText(path, JsonSerializer.Serialize("{ Items: {"));
                

            }
            else
            {
                Console.WriteLine("path already exists");
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
            appends.Add($"Item Stock: {item.ItemStock}");
            appends.Add($"Item PurchaseDate: {item.ItemPurchaseDate}");
            appends.Add("]\\n");



            var options = new JsonSerializerOptions { WriteIndented = true };
            List<Item> items = JsonSerializer.Deserialize<List<Item>>(File.ReadAllText(path));
            items.Add(item);
            File.WriteAllText(path, JsonSerializer.Serialize(items, options));
            

        }


        void caller(Item item)
        {
            Console.WriteLine("--------");
            Console.WriteLine("Item Name: ");
            item.ItemName = Console.ReadLine();
            Console.WriteLine("Item Description: ");
            item.ItemDescription = Console.ReadLine();
            Console.WriteLine("Item Price: NUMS ONLY ");
            item.ItemPrice = Console.ReadLine();
            Console.WriteLine("Item Quantity: NUMS ONLY ");
            item.ItemQuantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Item Stock: NUMS ONLY ");
            item.ItemStock = int.Parse(Console.ReadLine());
            Console.WriteLine("Item PurchaseDate: ");
            item.ItemPurchaseDate = Console.ReadLine();
            
            Console.WriteLine("--------");
            appender(item);
        }
    }







    class Item
    {
        private string itemName;
        private int itemNumber;
        private string itemDescription;
        private string itemPrice;
        private int itemQuantity;
        private int itemStock;
        private string itemPurchaseDate;


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

        public string ItemPrice
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
    }






}
