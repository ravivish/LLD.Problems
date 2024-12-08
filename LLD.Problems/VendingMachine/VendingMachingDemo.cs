namespace LLD.Problems.VendingMachine;

internal class VendingMachingDemo
{
    public static void SetupMain()
    {
        VendingMachine vendingMachine = new();

        #region Load Inventry
        Console.WriteLine("Loading Inventry...");
        Product product = new()
        {
            Name = "Coke",
            Price = 10
        };

        Inventry.AddProduct(vendingMachine, product);

        product = new()
        {
            Name = "Cookies",
            Price = 20
        };

        Inventry.AddProduct(vendingMachine, product);

        product = new()
        {
            Name = "Chips",
            Price = 5
        };
        Inventry.AddProduct(vendingMachine, product);
        Console.WriteLine("Inventry loaded.");
        #endregion


        #region Buy Product
        while (true)
        {
            Console.WriteLine("Select a product to buy.");
            vendingMachine.Products.Select((product, index) => new { index, product.Name, product.Price }).ToList().ForEach(item => Console.WriteLine($"{item.index + 1}: {item.Name} - {item.Price}"));
            Console.WriteLine("0: Exit");
            var productIndex = Convert.ToInt32(Console.ReadLine());

            if (productIndex == 0)
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            (bool result, Status status) = vendingMachine.BuyProduct(vendingMachine.Products[productIndex - 1], Coins.Five);
            if (result && status == Status.Success)
                Console.WriteLine($"Enjoy your {product.Name} and have a nice day.");
            else if (result && status == Status.InsufficientMoney)
                Console.WriteLine("You don't have enough money to buy this product.");
            else if (result && status == Status.ProductNotAvailable)
                Console.WriteLine("Sorry, this product is not available.");

        }
        #endregion

    }
}

public class VendingMachine //: VendingMachineBase
{
    public List<Product> Products { get; }
    public VendingMachine()
    {
        Products = new List<Product>();
    }

    private (bool, Status) DispenseProduct(Product product, int money)
    {
        var productObj = Products.FirstOrDefault(x => x.Name == product.Name);
        if (IsProductAvailable(product).Item1 == false)
            return (false, Status.ProductNotAvailable);

        if (productObj.Price > money)
            return (false, Status.InsufficientMoney);
        RemoveProduct(productObj);
        return (true, Status.Success);
    }

    /// <summary>
    /// Adding Product into Vending Machine
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    public bool AddProduct(Product product)
    {
        if (Products == null)
            return false;
        Products.Add(product);
        return true;
    }

    public bool RemoveProduct(Product product)
    {
        if (Products == null)
            return false;
        Products.Remove(product);
        return true;
    }

    public (bool,Status) BuyProduct(Product product, Coins coins)
    {
        if (Products == null)
            return (false, Status.ProductNotAvailable);

       return DispenseProduct(product, (int)coins);
    }

    public (bool,Status) BuyProduct(Product product, Notes notes)
    {
        if (Products == null)
            return (false, Status.ProductNotAvailable);

        return DispenseProduct(product, (int)notes);

    }

    public (bool, Status) IsProductAvailable(Product product)
    {
        if (Products.Any(x => x.Name == product.Name))
        {
            //Console.WriteLine($"Product {product.Name} is available.");
            return (true, Status.Success); //true;
        }
       
        return (false, Status.ProductNotAvailable);
    }
}


public class Product
{
    public required string Name { get; set; }
    public required int Price { get; set; }
}

public enum Coins
{
    One = 1,
    Two = 2,
    Five = 5
}

public enum Notes
{
    Ten = 10,
    Twenty = 20,
    Fifty = 50
}

public enum Status
{
    Success,
    InsufficientMoney,
    InsufficientCoins,
    InsufficientNotes,
    ProductNotAvailable
}



