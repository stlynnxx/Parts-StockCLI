using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace PartsStockCLI;

public class AddItem
{
    public void NewItem()
    {
        
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

            string[] appends = new string[25];
            appends[0] = "--------";
            appends[1] = $"Item Name: {itemName}";
            appends[2] = $"Item Description:  {itemDescription}";
            appends[3] = $"Item Price: {itemPrice}"; 
            appends[4] = $"Item Quantity: {itemQuantity}";
            appends[5] = $"Item Stock: {itemStock}";
            appends[6] = $"Item PurchaseDate: {itemPurchaseDate}";
            
            Console.WriteLine($"appends: {string.Join(", ", appends)}");
            File.AppendAllText(path, string.Join(Environment.NewLine, appends));
            
            
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
