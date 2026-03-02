namespace PartsStockCLI;

public class StorageLocations
{
    public void StorageMain()
    {
        StorageMenu();

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

        void StorageMenu() {
        string borderDashes = "-------------------------\n";

        string storageMenu = "1)Load Storage Location\n" +
                         "2)Edit Storage Location\n" +
                         "3)Create New Storage Location\n";

        Console.WriteLine(borderDashes);
        Console.WriteLine("Storage Menu\n");
        Console.WriteLine(storageMenu);
        Console.WriteLine(borderDashes);

        string userInput = Console.ReadLine();
            switch (userInput) {
                case "1":
                Console.WriteLine("You chose 1");
                break;
                case "2":
                Console.WriteLine("You chose 2");
                break;
                case "3":
                Console.WriteLine("You chose 3");
                break;
                default:
                Console.WriteLine("Invalid Input");
                break;
    }
}

}
}