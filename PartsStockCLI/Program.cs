namespace PartsStockCLI
{
    public class Program
    {
        public static bool displayBool = false;

        public static void Main()
        {
            if (displayBool)
            {
                Display display = new Display();
                Display.Art();
            }

            // Establishing a dir for the log files
            string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "PartsAndStockA");
            Directory.CreateDirectory(directory);
            // Establishing the file paths
            string storagePath = Path.Combine(directory, "StorageLocations.json");
            string sourcingPath = Path.Combine(directory, "Sourcing.json");
            string itemPath = Path.Combine(directory, "ItemList.json");

            Console.WriteLine("-------------------------\n" +
                              "1) New Item\n" +
                              "2) Item Search\n" +
                              "3) Sourcing\n" +
                              "4) Storage Location Setup\n" +
                              "5) Exit\n" +
                              "Dev Options: \n" +
                              "6) Delete File\n" +
                              "7) Overwrite File\n" +
                              "------------------------");
            int userIn = Convert.ToInt32(Console.ReadLine());

            StorageLocations storageLocations = new StorageLocations();
            AddItem add = new AddItem();
            Sourcing sourcing = new Sourcing();
            ItemSearch search = new ItemSearch();

            switch (userIn)
            {
                case 1:
                    add.NewItem(directory, itemPath, storagePath);
                    break;
                case 2:
                    search.Menu();
                    break;
                case 3:
                    sourcing.Main(directory, sourcingPath);
                    break;
                case 4:
                    storageLocations.StorageMain(directory, storagePath);
                    break;
                case 5:

                    break;

                case 6:
                    Console.WriteLine("File to be deleted: ");
                    string fileName = Console.ReadLine();
                    File.Delete(fileName);
                    Console.WriteLine("File deleted");
                    Main();
                    break;

                case 7:
                    string tmpPath = "";
                    Console.WriteLine("Filename to be overwritten");
                    string uI = Console.ReadLine();
                    switch (uI)
                    {
                        case "Sourcing.json":
                            tmpPath = sourcingPath;
                            break;
                        case "StorageLocations.json":
                            tmpPath = storagePath;
                            break;
                        case "ItemList.json":
                            tmpPath = itemPath;
                            break;
                        default:
                            Console.WriteLine("Please enter a valid file name");
                            break;

                    }

                    File.WriteAllText(tmpPath, "[]");
                    Console.WriteLine("File overwritten");
                    Main();
                    break;

                default:
                    Console.WriteLine("Switch default error");
                    break;

            }


        }

        public class Display
        {
            public static void Art()
            {
                Console.Title = "Parts Stock CLI";
                Console.ForegroundColor = ConsoleColor.Green;
                string art =
                    "__________                __           ____     _________ __                 __    \n\\______   \\_____ ________/  |_  ______/  _ \\   /   _____//  |_  ____   ____ |  | __\n |     ___/\\__  \\\\_  __ \\   __\\/  ___/>  _ </\\ \\_____  \\\\   __\\/  _ \\_/ ___\\|  |/ /\n |    |     / __ \\|  | \\/|  |  \\___ \\/  <_\\ \\/ /        \\|  | (  <_> )  \\___|    < \n |____|    (____  /__|   |__| /____  >_____\\ \\/_______  /|__|  \\____/ \\___  >__|_ \\\n                \\/                 \\/       \\/        \\/                  \\/     \\/\n";
                Console.WriteLine(art);

            }
        }
    }
}

        
            
        

        

    



