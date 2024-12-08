namespace LLD.Problems.VendingMachine;

public class Inventry
{
    public static void AddProduct(VendingMachine vendingMachine, Product product)
    {
        vendingMachine.AddProduct(product);
    }
    public static void RemoveProduct(VendingMachine vendingMachine, Product product)
    {
        vendingMachine.RemoveProduct(product);
    }


}
