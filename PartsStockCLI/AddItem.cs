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
                File.Create(path).Close();
                
            }
            else
            {
                
                
            }

            string[] appends = new string[25];
            appends[0] = "--------";
            appends[1] = "Item Name: ";
            appends[2] = itemName;
            appends[3] = "Item Description: ";
            appends[4] = itemDescription;
            appends[5] = "Item Price: "; 
            appends[6] = itemPrice.ToString();
            appends[7] = "Item Quantity: ";
            appends[8] = itemQuantity.ToString();
            appends[9] = "Item Stock: ";
            appends[10] = itemStock.ToString();
            appends[11] = "Item PurchaseDate: ";
            appends[12] = itemPurchaseDate;
            appends[13] = "Item PurchasePrice: ";
            appends[14] = itemPurchasePrice.ToString();
            appends[15] = "--------";
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
            ItemPrice = int.Parse(Console.ReadLine());
            Console.WriteLine("Item Quantity: NUMS ONLY ");
            ItemQuantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Item Stock: NUMS ONLY ");
            ItemStock = int.Parse(Console.ReadLine());
            Console.WriteLine("Item PurchaseDate: ");
            ItemPurchaseDate = Console.ReadLine();
            Console.WriteLine("Item PurchasePrice: ");
            ItemPurchasePrice = int.Parse(Console.ReadLine());
            Console.WriteLine("--------");
            appender();
        }
    }








    private string itemName;
        private string itemDescription;
        private int itemPrice;
        private int itemQuantity;
        private int itemStock;
        private string itemPurchaseDate;
        private int itemPurchasePrice;
        
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
        public int ItemPrice
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
        public int ItemPurchasePrice
        {
            get { return itemPurchasePrice; }
            set { itemPurchasePrice = value; }
        }
        
        




    }
