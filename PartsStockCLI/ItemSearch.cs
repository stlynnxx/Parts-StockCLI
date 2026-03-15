using System.Diagnostics;

namespace PartsStockCLI;

public class ItemSearch
{
    List<string> appends = new List<string>();
    public void Menu()
    {
        Console.Clear();
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
                SearchByName(delimiter);
                Console.WriteLine("Results: \n");
                for (int i = 0; i < appends.Count; i++)
                {
                    Console.WriteLine("Inside Switch Loop");
                    Console.WriteLine(appends[i]);
                }

                Console.WriteLine("Test Prints:");
                Console.WriteLine($"Appends 0: {appends[0]}");
                Console.WriteLine($"Appends 1: {appends[1]}");
                Console.WriteLine($"Appends 2: {appends[2]}");
                Console.WriteLine($" Appends 3: {appends[3]}");
                Console.WriteLine($"Appends 4: {appends[4]}");
                Console.WriteLine($"Appends 5: {appends[5]}");
                Console.WriteLine($"Appends 6: {appends[6]}");
                Console.WriteLine($"Appends 7: {appends[7]}");
                Console.WriteLine($"Appends 8: {appends[8]}");

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
        
        Console.WriteLine("Item name to search for: ");
        string itemName = Console.ReadLine();
        StreamReader sw =
            new StreamReader(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "ItemList.json"));
        string line = sw.ReadLine();
        appends.Add(line);
        Console.WriteLine($"Line check, line 53:\n {line}");
        line = sw.ReadLine();
        appends.Add(line);
            Console.WriteLine($"Line check, line 57:\n {line}");
            // Console.WriteLine("Line is not null!");
            // Console.WriteLine(line);
            // This little loop gets the searched term within the file and appends every
            // Line between the inital line where the term is found and the next delimiter to appends
            if (line != null)
            {
                    // Console.WriteLine("itemName Found!");
                    appends.Add(line);
                    // Console.WriteLine($"Appends: {appends[0]}");
                    Console.WriteLine($"line70 =  {line}");
                    line = sw.ReadLine();
                    appends.Add(line);
                    Console.WriteLine($"line72 =  {line}");
                    line = sw.ReadLine();
                    appends.Add(line);
                    Console.WriteLine($"line3 =  {line}");
                    line = sw.ReadLine();
                    appends.Add(line);
                    Console.WriteLine($"line4 =  {line}");
                    line = sw.ReadLine();
                    appends.Add(line);
                    Console.WriteLine($"line5 =  {line}");
                    line = sw.ReadLine();
                    appends.Add(line);
                    Console.WriteLine($"line6 =  {line}");
                    line = sw.ReadLine();
                    appends.Add(line);
                    Console.WriteLine($"line7 =  {line}");




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
        Console.WriteLine("Return Reached!");
        
    } 
}