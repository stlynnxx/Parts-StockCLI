using System.Xml;

namespace PartsStockCLI;

public class StorageLocations
{
    public void StorageMain()
    {
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "LocationsFile.json");
        
        string borderDashes = "--------";
        
        StorageMenu(path, borderDashes);
        
        // If a user wants to load a location, this menu is called for the load parameter
        void LoadLocationMenu(string path, string borderDash)
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
                    SearchByName(path, borderDash);
                    
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
        void SearchByName(string path, string borderDash)
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


                            if (line.Contains(borderDash))
                            {
                                i = appends.Length + 1;

                            }
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
        void createLocation(string path, string borderDashses)
        {
            string[] appends = new string[500];
            
            Console.WriteLine("Location Name:");
            string locationName = Console.ReadLine();
            Console.WriteLine("Details: ");
            string details = Console.ReadLine();
            Console.WriteLine("Location City:");
            string locationCity = Console.ReadLine();
            Console.WriteLine("Location State:");
            string locationState = Console.ReadLine();
            Console.WriteLine("Location Country:");
            string locationCountry = Console.ReadLine();
            
            // The border dashes demlit the location entries
            appends[0] = borderDashes;
            appends[1] = $"Location Name: {locationName}";
            appends[2] = $"Details: {details}";
            appends[3] = $"Location City: {locationCity}";
            appends[4] = $"Location State: {locationState}";
            appends[5] = $"Location Country: {locationCountry}";
            
            
            
            
            File.AppendAllText(path, string.Join(Environment.NewLine, appends));
            
            
            /* int length = appends.Length;
            string currentAppend;
            for (int i = 0; i < appendCounter; i++)
            {
                currentAppend = appends[i];
                File.AppendAllLines(path, [currentAppend]);


            }*/



        }

        // This is where the user decides what they want to do 
        void StorageMenu(string path, string borderDash)
        {
            
            string storageMenu = "1)Load Storage Location\n" +
                                  "2)Edit Storage Location\n" +
                                 "3)Create New Storage Location\n";

            Console.WriteLine(borderDash);
            Console.WriteLine("Storage Menu\n");
            Console.WriteLine(storageMenu);
            Console.WriteLine(borderDash);
            string userInput = Console.ReadLine();
                switch (userInput) {
                    case "1": 
                        LoadLocationMenu(path, borderDash);
                    break;
                    case "2":
                        Console.WriteLine("You chose 2");
                    break;
                    case "3":
                        createLocation(path, borderDash); 
                    break;
                    default:
                        Console.WriteLine("Invalid Input");
                    break;
            }
                
            
}

}

    public class StorageLocation()
    {
        private string locationName;
        private string details;
        private string locationCity;
        private string locationState;
        private string locationCountry;

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
        public string LocationState {
            get { return this.locationState; }
            set { this.locationState = value; }
        }
        public string LocationCountry {
            get { return this.locationCountry; }
            set { this.locationCountry = value; }
        }
        
    }

}