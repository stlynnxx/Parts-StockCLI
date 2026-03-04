using System.Xml;

namespace PartsStockCLI;

public class StorageLocations
{
    public void StorageMain()
    {
        
        string borderDashes = "--------";
        
        int routingNum = StorageMenu(borderDashes);
        Routing(routingNum, borderDashes);

        void LoadLocation()
        {
            Console.WriteLine("1)Location List\n" +
                              "2)Search by Location Name\n");
            string userIn = Console.ReadLine();
            if (userIn == "1")
            {
                Console.WriteLine("Location List Chosen");
            }
            else if (userIn == "2")
            {
                Console.WriteLine("Search by Location Name");
            }
            else
            {
                Console.WriteLine("LoadLocation.UserInput Error");
            }
        }

        StorageLocation CreateLocationFromInput()
        {
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
            return new StorageLocation
            {
                LocationName = locationName,
                Details =  details,
                LocationCity = locationCity,
                LocationState = locationState,
                LocationCountry = locationCountry
            };
        }

        void createLocation(string borderDashses)
        {
            int appendCounter = 0;
            string[] appends = new string[500];
            var s = CreateLocationFromInput();
            StreamWriter file = new StreamWriter("LocationsFile.json");
            
            // The border dashes demlit the location entries
            appends[0] = borderDashes;
            appendCounter++;
            appends[1] = s.LocationName;
            appendCounter++;
            appends[2] = s.Details;
            appendCounter++;
            appends[3] = s.LocationCity;
            appendCounter++;
            appends[4] = s.LocationState;
            appendCounter++;
            appends[5] = s.LocationCountry;
            appendCounter++;
            appends[6] = borderDashes;
            appendCounter++;
            
            
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "LocationsFile.json");
            File.AppendAllText(path, string.Join(Environment.NewLine, appends));
            
            
            /* int length = appends.Length;
            string currentAppend;
            for (int i = 0; i < appendCounter; i++)
            {
                currentAppend = appends[i];
                File.AppendAllLines(path, [currentAppend]);


            }*/



        }

        void Routing(int routeNum, string borderDashes)
        {
            switch (routeNum)
            {
                case 1:
                    // Load Storage Location
                    break;
                case 2:
                    // Edit Storage Location
                    break;
                case 3:
                    createLocation(borderDashes);
                    break;
                default:
                    break;
            }

        }

        static int StorageMenu(string borderDash)
        {
            int routingNum;
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
                        routingNum = 1;
                        Console.WriteLine("You chose 1");
                    break;
                    case "2":
                        routingNum = 2;
                        Console.WriteLine("You chose 2");
                    break;
                    case "3":
                        routingNum = 3;
                        Console.WriteLine("You chose 3");
                    break;
                    default:
                        routingNum = 0;
                        Console.WriteLine("Invalid Input");
                    break;
            }
                return routingNum;
            
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