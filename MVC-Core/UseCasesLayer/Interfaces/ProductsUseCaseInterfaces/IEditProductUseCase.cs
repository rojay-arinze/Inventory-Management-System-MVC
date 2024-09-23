using EntitiesLayer;

namespace UseCasesLayer.Interfaces.ProductsUseCaseInterfaces
{
    public interface IEditProductUseCase
    {
        void Execute(int productId, Product product);
    }
}