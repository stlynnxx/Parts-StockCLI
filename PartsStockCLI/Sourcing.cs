using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json;

namespace PartsStockCLI;

public class Sourcing
{
    public void Main()
    {
        Console.Clear();
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "Sourcing.json");
        SourcingLocation sourcingLocation = new SourcingLocation();
        string dashes = "--------";
        Menu(dashes);
        string userInput = Console.ReadLine();
        switch (userInput)
        {
            case "1":
                AddSourcingLocation(dashes, path, sourcingLocation);
                break;
            case "2":
                LoadSourcingLocation(LoadInterface(), path, path );
                break;
            case "3":
                Console.WriteLine("You chose three");
                break;
            case "4":
                Console.WriteLine("You chose four");
                break;
            case "5":
                Program.Main();
                break;
            default:
                Environment.Exit(0);
                break;
            
        }
        Console.Clear();
        Program.Main();
    }

    public void Menu(string dashes)
    {
        Console.WriteLine(dashes);
        Console.WriteLine("-Sourcing Menu-");
        Console.WriteLine("1) Add Sourcing Location");
        Console.WriteLine("2) Load Sourcing Location");
        Console.WriteLine("3) Delete Sourcing Location");
        Console.WriteLine("4) Review Sourcing Locations");
        Console.WriteLine("5) Home");
        Console.WriteLine("6) Exit Program");
        Console.WriteLine(dashes);
    }

    void AddSourcingLocation(string dashes, string path, SourcingLocation sourcingLocation)
    {
        
        Console.Clear();
        Console.WriteLine("Location Name: ");
        sourcingLocation.LocationName = Console.ReadLine();
        
        Console.WriteLine("Location Address: ");
        sourcingLocation.LocationAddress = Console.ReadLine(); 
        
        Console.WriteLine("Location City: ");
        sourcingLocation.LocationCity = Console.ReadLine();
        
        Console.WriteLine("Location State: ");
        sourcingLocation.LocationState = Console.ReadLine();
        
        Console.WriteLine("Location Country: ");
        sourcingLocation.LocationCountry = Console.ReadLine();
        
        
        if (!File.Exists(path))
        {
            Console.WriteLine("path null");
            File.Create(path).Close();
            File.WriteAllText(path, "[]");
        }
        else
        {
        }
        var options = new JsonSerializerOptions { WriteIndented = true };
        List<SourcingLocation> loc = JsonSerializer.Deserialize<List<SourcingLocation>>(File.ReadAllText(path));
        loc.Add(sourcingLocation);
        File.WriteAllText(path, JsonSerializer.Serialize(loc, options));

        

    }

    string LoadInterface()
    {
        Console.WriteLine("Which location would you like to load?");
        string userIn = Console.ReadLine();
        return userIn;

    }

    void LoadSourcingLocation(string searchParmeter, string dashes, string path)
    {
        List<Sourcing> loc = JsonSerializer.Deserialize<List<Sourcing>>(File.ReadAllText(path));
        
        string loadedFile = File.ReadAllText(path);
        if (loadedFile.Contains(searchParmeter))
        {
            Console.WriteLine("Search successful");
            // From here we need to get what we're searching for specifically 
            // from the loaded file
            Console.WriteLine(loadedFile);
        }
        else
        {
            Console.WriteLine("Search failed");
        }
    } 
    

    public class SourcingLocation
    {
        private string locationName;
        private string locationAddress;
        private string locationCity;
        private string locationState;
        private string locationCountry;
        
        public string LocationName
        {
            get {  return locationName; }
            set {  locationName = value; }
        }

        public string LocationAddress
        {
            get {  return locationAddress; }
            set {  locationAddress = value; }
        }

        public string LocationCity
        {
            get {  return locationCity; }
            set {  locationCity = value; }
        }
        public string LocationState
        {
            get {  return locationState; }
            set {  locationState = value; }
        }
        public string LocationCountry
        {
            get {  return locationCountry; }
            set {  locationCountry = value; }
        }
        
    }
}