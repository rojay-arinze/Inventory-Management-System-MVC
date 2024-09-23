using EntitiesLayer;

namespace UseCasesLayer.Interfaces.ProductsUseCaseInterfaces
{
    public interface IViewProductsUseCase
    {
        IEnumerable<Product> Execute(bool loadCategory = false);
    }
}