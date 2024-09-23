namespace UseCasesLayer.Interfaces.ProductsUseCaseInterfaces
{
    public interface ISellProductUseCase
    {
        void Execute(string cashierName, int productId, int qtyToSell);
    }
}