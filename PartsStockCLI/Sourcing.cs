using System.ComponentModel;
using System.Diagnostics;

namespace PartsStockCLI;

public class Sourcing
{
    public void Main()
    {
        Console.Clear();
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "Sourcing.json");
        string dashes = "--------";
        Menu(dashes);
        string userInput = Console.ReadLine();
        switch (userInput)
        {
            case "1":
                AddSourcingLocation(dashes, path);
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

    void AddSourcingLocation(string dashes, string path)
    {
        SourcingLocation location = new SourcingLocation();
        string[] append = new string[10];
        append[0] = dashes;
        Console.Clear();
        Console.WriteLine("Location Name: ");
        location.LocationName = Console.ReadLine();
        append[1] = $"Location Name: {location.LocationName}";
        Console.WriteLine("Location Address: ");
        location.LocationAddress = Console.ReadLine(); 
        append[2] = $"Location Address: {location.LocationAddress}";
        Console.WriteLine("Location City: ");
        location.LocationCity = Console.ReadLine();
        append[3] = $"Location City: {location.LocationCity}";
        Console.WriteLine("Location State: ");
        location.LocationState = Console.ReadLine();
        append[4] = $"Location State: {location.LocationState}";
        Console.WriteLine("Location Country: ");
        location.LocationCountry = Console.ReadLine();
        append[5] = $"Location Country: {location.LocationCountry}";
        
        if (!File.Exists(path))
        {
            File.Create(path).Close();
        }
        File.AppendAllLines(path, append);
    }

    string LoadInterface()
    {
        Console.WriteLine("Which location would you like to load?");
        string userIn = Console.ReadLine();
        return userIn;

    }

    void LoadSourcingLocation(string searchParmeter, string dashes, string path)
    {
        
        
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