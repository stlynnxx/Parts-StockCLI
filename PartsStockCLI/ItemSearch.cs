namespace PartsStockCLI;

public class ItemSearch
{
    public void Input()
    {
        string delimiter = "--------";
        Console.WriteLine("What parameter would you like to search by?");
        Console.WriteLine("1) Item Name" + 
                      "2) Item Number" +
                      "3) Storage Location" +
                      "4) Sourcing Location");
        string userParameter =  Console.ReadLine();
        switch (userParameter)
        {
            case "1":
                // Item  name
                SearchByName(delimiter);
                break;
            case "2":
                // Item number
                break;
            case "3":
                // Storage Location
                break;
            case "4":
                // Source Location
                break;
            default:
                break;
        }
    }

    public void SearchByName(string delimiter)
    {
        string[] appends = new string[250]; 
        Console.WriteLine("Item name to search for: ");
        string itemName = Console.ReadLine();
        StreamReader sw = new StreamReader(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ItemList.json"));
        string line = sw.ReadLine();
        while (line != null)
        {
            if (line.Contains(itemName))
            {
                appends[0] = line;
                line = sw.ReadLine();
                for (int i = 1; i < appends.Length; i++)
                {
                    if (line != delimiter)
                    {
                        appends[i] = line;
                    }

                    if (line.Contains(delimiter))
                    {
                        appends[i] = line;
                        i = appends.Length;
                    }
                }
                sw.Close();
            }
            
        }
    }
}