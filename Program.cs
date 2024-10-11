using System;

namespace BikeRentalManagement_V2;

public class Program
{
    static void Main(string[] args)
    {
        BikeRepository repository = new BikeRepository();

        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("+-+-+-+- Bike Rental Management System +-+-+-+-");
            Console.WriteLine("\n1. Add a Bike");
            Console.WriteLine("2. View All Bikes");
            Console.WriteLine("3. Update a Bike");
            Console.WriteLine("4. Delete a Bike");
            Console.WriteLine("5. Exit");
            Console.Write("\nChoose an option: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Clear();
                    repository.InsertBikes();
                    break;
                case "2":
                    Console.Clear();
                    repository.GetAllBikes();
                    break;
                case "3":
                    Console.Clear();
                    repository.UpdateBikes();
                    break;
                case "4":
                    Console.Clear();
                    repository.DeleteBike();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Choose the Correct Option");
                    break;
            }
            if (!exit)
            {
                Console.WriteLine("Press Enter to Continue....");
                Console.ReadLine();
            }
        }
    }
}
