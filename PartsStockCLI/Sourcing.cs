using System.Security.Cryptography;
using System.Text.Json;

namespace PartsStockCLI;

public class Sourcing
{
    public void Main()
    {
        try
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
                    Console.WriteLine("Case 2!");
                    LoadSourcingLocation(dashes, path );
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
            // Console.Clear();
            Program.Main();

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
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
        try
        {
            Console.Clear();
        
            Console.WriteLine("Location Name: ");
            sourcingLocation.LocationName = Console.ReadLine();
        
            Console.WriteLine("Location Address: ");
            sourcingLocation.LocationAddress = Console.ReadLine(); 
        
            Console.WriteLine("Location Type: ");
            sourcingLocation.LocationCity = Console.ReadLine();
        
            if (!File.Exists(path))
            {
                Console.WriteLine("path null");
                File.Create(path).Close();
                File.WriteAllText(path, "[]");
            }
           
            var options = new JsonSerializerOptions { WriteIndented = true };
            List<SourcingLocation> loc = JsonSerializer.Deserialize<List<SourcingLocation>>(File.ReadAllText(path));
            loc.Add(sourcingLocation);
            File.WriteAllText(path, JsonSerializer.Serialize(loc, options));


        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        
        
        

    }



    void LoadSourcingLocation(string dashes, string path)
    {
        Console.WriteLine("Enter the Sourcing Location: ");
        string searchParameter = Console.ReadLine();
        // From here we need to get what we're searching for specifically 
        // from the loaded file
        
        
            Console.WriteLine("Trying!");
            string jsonContent = File.ReadAllText(path);
            if (string.IsNullOrWhiteSpace(jsonContent))
            {
                Console.WriteLine("jsoncontent null");
            }
            else
            {
                
                JsonDocument doc = JsonDocument.Parse(jsonContent);
                foreach (JsonElement element in doc.RootElement.EnumerateArray())
                {
                    if (element.TryGetProperty("LocationName", out JsonElement value))
                    {
                        string location = value.GetString();
                        if (location == searchParameter)
                        {
                            foreach (JsonProperty prop in element.EnumerateObject())
                            {
                                Console.WriteLine($"{prop.Name}: {prop.Value}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Property 'SourcingLocation' not found.");
                    }
                }
            }
            
    } 
    

    public class SourcingLocation
    {
        private string locationName;
        private string locationAddress;
        private string locationCity;
        private string locationState;
        

        
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
        
    }
}