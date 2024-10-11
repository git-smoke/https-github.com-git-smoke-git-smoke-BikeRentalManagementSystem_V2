using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.DataClassification;

namespace BikeRentalManagement_V2;

public class BikeRepository
{
    private string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=BikeRentalManagement;Trusted_Connection=True;";

    public void InsertBikes()
    {
        try
        {
            Console.Write("Enter Bike Id: ");
            string bikeId = Console.ReadLine();
            Console.Write("Enter Bike Brand: ");
            string brand = Console.ReadLine();
            Console.Write("Enter Bike Model: ");
            string model = Console.ReadLine();
            Console.Write("Enter Bike RentalPrice: ");
            decimal rentalPrice = decimal.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO Bikes(BikeId,Brand,Model,RentalPrice) VALUES(@bikeId, @brand, @model, @rentalPrice)";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@bikeId", bikeId);
                    command.Parameters.AddWithValue("@brand", brand);
                    command.Parameters.AddWithValue("@model", model);
                    command.Parameters.AddWithValue("@rentalPrice", rentalPrice);
                    int row = command.ExecuteNonQuery();

                    if (row != 0)
                    {
                        Console.WriteLine("\nBike Added Successfully");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Occured: {ex.Message}");
        }
    }

    public void UpdateBikes()
    {
        try
        {
            Console.WriteLine("------------");
            Console.WriteLine("Update Bikes");
            Console.WriteLine("------------");

            Console.Write("\nEnter Bike Id: ");
            string bikeId = Console.ReadLine();
            Console.Write("Enter New Brand: ");
            string brand = Console.ReadLine();
            Console.Write("Enter New Model");
            string model = Console.ReadLine();
            Console.Write("Enter New Rental Price");
            decimal rentalPrice = decimal.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string updateQuery = "UPDATE Bikes SET BikeId = @bikeId, Brand = @brand, Model = @model, RentalPrice = @rentalPrice";
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@bikeId", bikeId);
                    command.Parameters.AddWithValue("@brand", brand);
                    command.Parameters.AddWithValue("@model", model);
                    command.Parameters.AddWithValue("@rentalPrice", rentalPrice);
                    int row = command.ExecuteNonQuery();

                    if (row != 0)
                    {
                        Console.WriteLine("\nUpdated Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Check your Id again");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error Occured : " + ex.Message);
        }
    }

    public void DeleteBike()
    {
        try
        {
            Console.WriteLine("********");
            Console.WriteLine("Delete Bike");
            Console.WriteLine("********");

            Console.Write("\nEnter Bike Id: ");
            string bikeId = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM Bikes WHERE BikeId = @bikeId";
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@bikeId", bikeId);
                    int row = command.ExecuteNonQuery();

                    if (row != 0)
                    {
                        Console.WriteLine("\nSucessfully deleted");
                    }
                    else
                    {
                        Console.WriteLine("Check your Id and try again");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error Occured: " + ex.Message);
        }
    }


    public void GetAllBikes()
    {
        List<Bike> bikes = new List<Bike>();
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Bikes";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bikes.Add(new Bike(
                              reader.GetString(0),
                              reader.GetString(1),
                              reader.GetString(2),
                              reader.GetDecimal(3)
                            ));
                        }
                    }
                }
            }
            foreach (Bike bike in bikes)
            {
                Console.WriteLine($"{bikes.ToString()}");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }

    }

    public Bike GetBikeById()
    {

        try
        {
            Console.Write("Enter Bike Id : ");
            string bikeId = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT * FROM Bikes WHERE BikeId = @bikeId";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@bikeId", bikeId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Bike(
                              reader.GetString(0),
                              reader.GetString(1),
                              reader.GetString(2),
                              reader.GetDecimal(3)
                            );
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
        return null;
    }

}


