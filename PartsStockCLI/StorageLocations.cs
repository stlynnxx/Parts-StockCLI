using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PartsStockCLI;

public class StorageLocations
{
    public void StorageMain()
    {
        // This needs error handling
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
                    NameSearch searcher = new NameSearch(path); searcher.search();

                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;

            }

        }

        // This is going to be for loading the entire Storage Locations list
        string LoadList(string path)
        {
            string load = File.ReadAllText(path);
            return load;
        }

        
        // This is for creating a new storage location
        void createLocation(string path)
        {
            // Var declarations
            int? idIdx = 1;
            int? parentID = 1;
            int subCount = 0;
            bool sublocations = false;
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                
            };
            StorageLocation storageLocation = new StorageLocation();
            
            // Loading JSON file
            List<StorageLocation> loc = JsonSerializer.Deserialize<List<StorageLocation>>(File.ReadAllText(path), options);
            
            // Establishing parentID start point
            int locCount = loc.Count;
           
            if (locCount >= 1)
            {
                locCount++;
                parentID = locCount;
            }

            storageLocation.Id = idIdx;
            Console.WriteLine("Location Name:");
            storageLocation.LocationName = Console.ReadLine();
            Console.WriteLine("Details: ");
            storageLocation.Details = Console.ReadLine();
            Console.WriteLine("Location City:");
            storageLocation.LocationCity = Console.ReadLine();
            Console.WriteLine("Location Type:");
            storageLocation.LocationType = Console.ReadLine();
            Console.WriteLine("Does this location have any sublocations? (y/N)");
            string userInput = Console.ReadLine();
            if (userInput == "y")
            {
                Console.WriteLine("Sublocation count: (nums only)");
                subCount = int.Parse(Console.ReadLine());
                sublocations = true;
            }

            Console.WriteLine("Line 129");
            storageLocation.ParentId = parentID;
            Console.WriteLine("Line 131");
            storageLocation.Children = new List<StorageLocation>();
            if (sublocations == true)
            {
                for (int i = 0; i < subCount; i++)
                {
                    StorageLocation subLocation = new StorageLocation();
                    subLocation.Id = idIdx + i + 1;
                    Console.WriteLine("Sublocation Name: ");
                    subLocation.LocationName = Console.ReadLine();
                    subLocation.ParentId = storageLocation.Id;
                    subLocation.Parent = storageLocation;
                    storageLocation.Children.Add(subLocation);
                }
            }



            Console.WriteLine("Line 146");

            if (!File.Exists(path))
            {
                Console.WriteLine("Line 152");
                Console.WriteLine("path null");
                File.Create(path).Close();
                File.WriteAllText(path, "[]");
            }
            Console.WriteLine("Line 169");
           
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
            switch (userInput)
            {
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
    public class NameSearch(string path)
    {
        public void search()
        {
            int lineCounter = 0;
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
                    // Console.WriteLine($"line check: {line}");
                    // Console.WriteLine("Line check level");

                    if (line.Contains(userInput))
                    {
                        appends[0] = line;
                        int index = 1;
                                              
                            while((line = sr.ReadLine()) !=null && index < appends.Length) // Read until the end of the JSON block or array
                            {
                                appends[index] = line;
                                index++;

                                if (line.Trim() == "}" || line.Trim() == "},") // Stop only when the main parent object block closes (e.g., "  }" or "  },") // avoiding early stops on child objects inside the array
                                {
                                    break;
                                }
                            }
                            break;
                                                         
                    }
                }
            }

            Console.WriteLine("WriteLine Reached");
            for (int k = 0; k < appends.Length; k++)
            {
                if(!string.IsNullOrWhiteSpace(appends[k])) // Only print non empty slots to prevent blank lines
                {
                    Console.WriteLine(appends[k]);

                }
            }
        }
    }


    }

    public class SaveLocation
    {
        private string locationName;
        private string details;
        private string locationCity;
        private string locationState;
        private string locationCountry;
    }

    public class SubLocation
    {
        private string locationName;
        private string parentLocationName;
        private int? id;
        private int? parentId;
        public SubLocation Parent { get; set; }
        public List<SubLocation> Children { get; set; }
    }

    public class StorageLocation
    {
       
       
        private string locationName;
        private string details;
        private string locationCity;
        private string locationState;
        private string locationCountry;
        private string locationType;
        private int? id;
        private int? parentId;
       
       [JsonIgnore]
        public StorageLocation Parent { get; set; }

        // Explicit order so parent scalar fields write before Children (STJ defaults to declaration order; Children used to be declared first).
        [JsonPropertyOrder(0)]
        public string LocationName {
            get { return this.locationName; }
            set { this.locationName = value; }
        }
        [JsonPropertyOrder(1)]
        public int? Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        [JsonPropertyOrder(2)]
        public int? ParentId
        {
            get { return this.parentId; }
            set {  this.parentId = value; }
        }
        [JsonPropertyOrder(3)]
        public string LocationCity {
            get { return this.locationCity; }
            set { this.locationCity = value; }
        }
        [JsonPropertyOrder(4)]
        public string LocationType
        {
            get { return this.locationType; }
            set { this.locationType = value; }
        }
        [JsonPropertyOrder(5)]
        public string Details
        {
            get { return this.details; }
            set { this.details = value; }
        }
        [JsonPropertyOrder(6)]
        public List<StorageLocation> Children { get; set; }
    }

