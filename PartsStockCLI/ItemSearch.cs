using System.Diagnostics;

namespace PartsStockCLI;

public class ItemSearch
{
    public void DeMenu()
    {
        var searchReturn = new List<string>();
        string delimiter = "--------";
        Console.WriteLine("What parameter would you like to search by?");
        Console.WriteLine("1) Item Name\n" +
                          "2) Item Number\n" +
                          "3) Storage Location\n" +
                          "4) Sourcing Location\n");
        string userParameter = Console.ReadLine();
        switch (userParameter)
        {
            case "1":
                // Item  name
                searchReturn.Add(SearchByName(delimiter));
                Console.WriteLine("Results: \n");
                for (int i = 0; i < searchReturn.Count; i++) {
                    Console.WriteLine("Inside Switch Loop");
                    Console.WriteLine(searchReturn[i]);
                }

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

    public string SearchByName(string delimiter)
    {   var appends = new List<string>();
        
        Console.WriteLine("Item name to search for: ");
        string itemName = Console.ReadLine();
        StreamReader sw =
            new StreamReader(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "ItemList.json"));
        string line = sw.ReadLine();
        Console.WriteLine("Line check");
        
        
            line = sw.ReadLine();
            // Console.WriteLine("Line is not null!");
            // Console.WriteLine(line);
            // This little loop gets the searched term within the file and appends every
            // Line between the inital line where the term is found and the next delimiter to appends
            if (line != null && line.Contains(itemName))
            {
                while (line != null)
                {


                    // Console.WriteLine("itemName Found!");
                    appends.Add(line);
                    // Console.WriteLine($"Appends: {appends[0]}");
                    // Console.WriteLine($"line =  {line}");
                    line = sw.ReadLine();
                    // Console.WriteLine($"line =  {line}");
                    for (int i = 1; i < appends.Count; i++)
                    {
                        if (line != delimiter)
                        {
                            appends[i] = line;
                        }

                        if (line.Contains(delimiter))
                        {
                            appends[i] = line;
                            i = appends.Count;
                        }
                    }
                }


            

        }
        Console.WriteLine("Return Reached!");
        return appends[^1];
    }
}