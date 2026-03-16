using System.Text.Json;

namespace PartsStockCLI;

public class AddItem
{
    public void NewItem()
    {
        Console.Clear();
        /* caller() collects the input for the new item fields and
         assigns them, appender appends them*/
        caller();

        void appender()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "ItemList.json");
            if (path == null)
            {
                Console.WriteLine("path null");
                File.Create(path).Close();
                
            }
            else
            {
                Console.WriteLine("path already exists");
                
                
            }

            List<string> appends = new List<string>();
            
            appends.Add("{Items: {");
            appends.Add($"Item Name: {itemName}");
            appends.Add($"Item Description:  {itemDescription}");
            appends.Add($"Item Price: {itemPrice}"); 
            appends.Add("Item Quantity: {itemQuantity}");
            appends.Add($"Item Stock: {itemStock}");
            appends.Add($"Item PurchaseDate: {itemPurchaseDate}");
            appends.Add("--------");
            appends.Add("}}");
            
            
            
            string jsonAppends = JsonSerializer.Serialize(appends);
            File.AppendAllText(path, string.Join(Environment.NewLine, jsonAppends));
            

        }


        void caller()
        {
            Console.WriteLine("--------");
            Console.WriteLine("Item Name: ");
            ItemName = Console.ReadLine();
            Console.WriteLine("Item Description: ");
            ItemDescription = Console.ReadLine();
            Console.WriteLine("Item Price: NUMS ONLY ");
            ItemPrice = Console.ReadLine();
            Console.WriteLine("Item Quantity: NUMS ONLY ");
            ItemQuantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Item Stock: NUMS ONLY ");
            ItemStock = int.Parse(Console.ReadLine());
            Console.WriteLine("Item PurchaseDate: ");
            ItemPurchaseDate = Console.ReadLine();
            
            Console.WriteLine("--------");
            appender();
        }
    }








    private string itemName;
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
