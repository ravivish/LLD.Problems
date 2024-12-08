namespace LLD.Problems.VendingMachine;

internal class VendingMachingDemo
{
    public static void SetupMain()
    {
        VendingMachine vendingMachine = new();

        Product product = new()
        {
            Name = "Coke",
            Price = 10
        };

        vendingMachine.AddProduct(product);


    }
}

public class VendingMachine : VendingMachineBase
{
    public List<Product> Products { get; }
    public VendingMachine()
    {
        Products = new List<Product>();
    }

    /// <summary>
    /// Adding Product into Vending Machine
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    public override bool AddProduct(Product product)
    {
        if (Products == null)
            return false;
        Products.Add(product);
        return true;
    }

    public override bool RemoveProduct(Product product)
    {
        if (Products == null)
            return false;
        Products.Remove(product);
        return true;
    }
}


public class Product
{
    public required string Name { get; set; }
    public required int Price { get; set; }
}

enum Coins
{
    One = 1,
    Two = 2,
    Five = 5
}

enum Notes
{
    Ten = 10,
    Twenty = 20,
    Fifty = 50
}



