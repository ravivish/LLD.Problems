using static LLD.Problems.VendingMachine.VendingMachingDemo;

namespace LLD.Problems.VendingMachine;

public abstract class VendingMachineBase
{

    public abstract bool AddProduct(Product product);

    public abstract bool RemoveProduct(Product product);

}
