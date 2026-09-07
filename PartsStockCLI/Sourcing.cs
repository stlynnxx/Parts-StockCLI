using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text.Json;

namespace PartsStockCLI;

public class Sourcing
{
    public void Main(string directory, string path)
    {
        try
        {
            bool menuBool = true;
            while (menuBool)
            {
                SourcingLocation sourcingLocation = new SourcingLocation();
                Console.Clear();
                string dashes = "--------";
                Console.WriteLine(dashes);
                Console.WriteLine("-Sourcing Menu-");
                Console.WriteLine("1) Add Sourcing Location");
                Console.WriteLine("2) Load Sourcing Location");
                Console.WriteLine("3) Delete Sourcing Location");
                Console.WriteLine("4) Review Sourcing Locations");
                Console.WriteLine("B)Go back");
                Console.WriteLine("Type 'exit' to exit the program");
                Console.WriteLine(dashes);
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddSourcingLocation(dashes, path, sourcingLocation);
                        menuBool = false;
                        break;
                    case "2":
                        Console.WriteLine("Case 2!");
                        LoadSourcingLocation(dashes, path);
                        menuBool = false;
                        break;
                    case "3":
                        Console.WriteLine("You chose three");
                        menuBool = false;
                        break;
                    case "4":
                        Console.WriteLine("You chose four");
                        menuBool = false;
                        break;
                    case "B":
                        Program.Main();
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        menuBool = true;
                        break;

                }
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
    
    void AddSourcingLocation(string dashes, string path, SourcingLocation sourcingLocation)
    {
        try
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("path null");
                File.Create(path).Close();
                File.WriteAllText(path, "[]");
            }
            Console.Clear();
            Console.WriteLine("Location Name: ");
            sourcingLocation.LocationName = Console.ReadLine();
            Console.WriteLine("Location Address: ");
            sourcingLocation.LocationAddress = Console.ReadLine();
            Console.WriteLine("Location State: ");
            sourcingLocation.LocationState = Console.ReadLine();
            Console.WriteLine("Location Type: ");
            sourcingLocation.LocationCity = Console.ReadLine();
            Console.WriteLine("Notes: ");
            sourcingLocation.Notes = Console.ReadLine();
            var options = new JsonSerializerOptions { WriteIndented = true };
            List<SourcingLocation>? loc = JsonSerializer.Deserialize<List<SourcingLocation>>(File.ReadAllText(path));
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
        Console.WriteLine("Trying!");
        string jsonContent = File.ReadAllText(path);
        if (string.IsNullOrWhiteSpace(jsonContent))
        {
            Console.WriteLine("jsoncontent null");
        }
        else
        {
            try
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
            catch (JsonException e)
            {
                
            }
            

        }
            
    } 
    

    public class SourcingLocation
    {
        private string locationName;
        private string locationAddress;
        private string locationCity;
        private string locationState;
        private string notes;
        

        
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
        public string Notes
        {
            get {  return notes; }
            set {  notes = value; }
            
        }
        
        
    }
}