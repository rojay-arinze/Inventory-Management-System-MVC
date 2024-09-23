using EntitiesLayer;

namespace UseCasesLayer.Interfaces.ProductsUseCaseInterfaces
{
    public interface IViewSelectedProductUseCase
    {
        Product? Execute(int productId);
    }
}