namespace BikeRentalManagement_V2;

public class Bike
{

    public string BikeId { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public decimal RentalPrice { get; set; }

    public Bike(string bikeId, string brand, string model, decimal rentalPrice)
    {
        BikeId = bikeId;
        Brand = brand;
        Model = model;
        RentalPrice = rentalPrice;
    }

}
