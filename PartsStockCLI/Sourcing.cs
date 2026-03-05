using System.Diagnostics;

namespace PartsStockCLI;

public class Sourcing
{
    public void Main()
    {
        string dashes = "--------";
        Menu(dashes);
        string userInput = Console.ReadLine();
        switch (userInput)
        {
            case "1":
                Console.WriteLine("You chose one");
                AddSourcingLocation(dashes);
                break;
            case "2":
                Console.WriteLine("You chose two");
                break;
            case "3":
                Console.WriteLine("You chose three");
                break;
            case "4":
                Console.WriteLine("You chose four");
                break;
            case "5":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("You chose three");
                break;
            
        }
    }

    public void Menu(string dashes)
    {
        Console.WriteLine(dashes);
        Console.WriteLine("-Sourcing Menu-");
        Console.WriteLine("1) Add Sourcing Location");
        Console.WriteLine("2) Edit Sourcing Location");
        Console.WriteLine("3) Delete Sourcing Location");
        Console.WriteLine("4) Review Sourcing Locations");
        Console.WriteLine("5) Exit");
        Console.WriteLine(dashes);
    }

    void AddSourcingLocation(string dashes)
    {
        string[] appends = new string[500];
        Console.WriteLine("Location Name: ");
        string locationName = Console.ReadLine();
        Console.WriteLine("Location Address: ");
        string locationAddress = Console.ReadLine();
        Console.WriteLine("Location City: ");
        string locationCity = Console.ReadLine();
        Console.WriteLine("Location State: ");
        string locationState = Console.ReadLine();
        Console.WriteLine("Location Country: ");
        string locationCountry = Console.ReadLine();
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "Sourcing.json");
        if (!File.Exists(path))
        {
            File.Create(path).Close();
        }

        appends[0] = dashes;
        appends[1] = $"Location Name: {locationName}";
        appends[2] = $"Location Address: {locationAddress}";
        appends[3] = $"Location City: {locationCity}";
        appends[4] = $"Location State: {locationState}";
        appends[5] = $"Location Country: {locationCountry}";
        appends[6] = dashes;
        File.AppendAllLines(path, appends);

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