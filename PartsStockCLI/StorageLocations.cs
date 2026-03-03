namespace PartsStockCLI;

public class StorageLocations
{
    public void StorageMain()
    {
        
        string borderDashes = "----";
        
        int routingNum = StorageMenu(borderDashes);
        Routing(routingNum);

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

        void createLocation()
        {
            string[] appends = new string[500];
            
            StorageLocation s = new StorageLocation();
            Console.WriteLine("Location Name:");
            string locName = Console.ReadLine();
            s.LocationName = locName;
            Console.WriteLine("Location City:");
            string locCity = Console.ReadLine();
            s.LocationCity = locCity;
            string locState = Console.ReadLine();
            s.LocationState = locState;
            string locCountry = Console.ReadLine();
            s.LocationCountry = locCountry;
            appends[0] = s.LocationName;
            appends[1] = s.LocationCity;
            appends[2] = s.LocationState;
            appends[3] = s.LocationCountry;
            
            
            
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "Locations.json");
            if (path == null)
            {
                File.Create(path).Close();
            }
            int length = appends.Length;
            for (int i = 0; i < length; i++)
            {
                File.Delete(Path.Combine(path, appends[i]));
            }
            

        }

        void Routing(int routeNum)
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
                    createLocation();
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
        private string locationCity;
        private string locationState;
        private string locationCountry;

        public string LocationName {
            get { return this.locationName; }
            set { this.locationName = value; }
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