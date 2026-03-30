using System.Text.Json;

namespace PartsStockCLI;

public class StorageLocations
{
    public void StorageMain()
    {
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "StorageLocations.json");
        
        
        // string borderDashes = "--------";
        
        StorageMenu(path);
        
        // If a user wants to load a location, this menu is called for the load parameter
        void LoadLocationMenu(string path)
        {
            Console.WriteLine("1)Location List\n" +
                              "2)Search by Location Name\n");
            string userIn = Console.ReadLine();
            switch (userIn)
            {
                case "1":
                    Console.WriteLine(LoadList(path));
                    break;
                case "2":
                    SearchByName(path);
                    
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
                
            }
            
        }
        // This is going to be for loading the entire Storage Locations list
        string LoadList(string path)
        {   string load = File.ReadAllText(path);
            return load;
        }
        // This will be for searching for a specific storage location via name
        void SearchByName(string path)
        {
            string[] appends = new string[50];
            Console.WriteLine("Enter the name to search by: ");
            string userInput = Console.ReadLine();
            //string loadedFile = LoadList(path);
            using (StreamReader sr = new StreamReader(path))
            {
                string line = sr.ReadLine();
                // string fullFile = sr.ReadToEnd();
                // int fileLen =  fullFile.Length;
                if (line == null)
                {
                    Console.WriteLine($"Line Null, line: {line}");
                }

                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine($"line check: {line}");
                    Console.WriteLine("Line check level");
                    
                    if (line.Contains(userInput))
                    {
                        
                        appends[0] = line;
                        for (int i = 1; i < appends.Length; i++)
                        {
                            line = sr.ReadLine();
                            appends[i] = line;


                            
                        }

                        break;
                    }
                }
            }   
            Console.WriteLine("WriteLine Reached");
            for (int k = 0; k < appends.Length; k++) {
                Console.WriteLine(appends[k]);
            }

            
        }

        // This is for creating a new storage location
        void createLocation(string path)
        {
            int subCount = 0;
            bool sublocations = false;
            Console.WriteLine("Does this location have any sublocations? (y/N)");
            string userInput = Console.ReadLine();
            if (userInput == "y")
            {
                Console.WriteLine("Sublocation count: (nums only)");
                subCount = int.Parse(Console.ReadLine());
                sublocations = true;
            }
            
            int idIdx = 1;
            int? parentID = null;
            StorageLocation storageLocation = new StorageLocation();
            storageLocation.Id = idIdx;
            
            Console.WriteLine("Location Name:");
            storageLocation.LocationName = Console.ReadLine();
            Console.WriteLine("Details: ");
            storageLocation.Details = Console.ReadLine();
            Console.WriteLine("Location City:");
            storageLocation.LocationCity = Console.ReadLine();
            Console.WriteLine("Location Type:");
            storageLocation.LocationType = Console.ReadLine();
            
            storageLocation.ParentId = parentID;
            if (sublocations == true)
            {
                
                for (int i = 0; i <= subCount; i++)
                {
                    StorageLocation subLocation = new StorageLocation(); 
                    subLocation.Id = idIdx + 1;
                    Console.WriteLine("Sub Location Name: ");
                    subLocation.LocationName = Console.ReadLine();
                    subLocation.ParentId = 1;
                    subLocation.Parent = storageLocation;
                }
            }

            if (!File.Exists(path))
            {
                Console.WriteLine("path null");
                File.Create(path).Close();
                File.WriteAllText(path, "[]");
            }
           
            
            
            var options = new JsonSerializerOptions { WriteIndented = true };
            List<StorageLocation> loc = JsonSerializer.Deserialize<List<StorageLocation>>(File.ReadAllText(path));
            loc.Add(storageLocation);
            File.WriteAllText(path, JsonSerializer.Serialize(loc, options));    
        }

        // This is where the user decides what they want to do 
        void StorageMenu(string path)
        {
            
            string storageMenu = "1)Load Storage Location\n" +
                                  "2)Edit Storage Location\n" +
                                 "3)Create New Storage Location\n";

            
            Console.WriteLine("Storage Menu\n");
            Console.WriteLine(storageMenu);
            
            string userInput = Console.ReadLine();
                switch (userInput) {
                    case "1": 
                        LoadLocationMenu(path);
                    break;
                    case "2":
                        Console.WriteLine("You chose 2");
                    break;
                    case "3":
                        createLocation(path);
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                    break;
            }
                
            
}

}

    public class StorageLocation
    {
       
       
        private string locationName;
        private string details;
        private string locationCity;
        private string locationState;
        private string locationCountry;
        private string locationType;
        private int id;
       
        public StorageLocation Parent { get; set; }
        public List<StorageLocation> Children { get; set; }

        public string LocationName {
            get { return this.locationName; }
            set { this.locationName = value; }
        }

        public string Details
        {
            get { return this.details; }
            set { this.details = value; }
        }

        public string LocationCity {
            get { return this.locationCity; }
            set { this.locationCity = value; }
        }

        public string LocationType
        {
            get { return this.locationState; }
            set { this.locationState = value; }
        }
        

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public int? ParentId
        {
            get { return this.ParentId; }
            set {  this.ParentId = value; }
        }
    }

}