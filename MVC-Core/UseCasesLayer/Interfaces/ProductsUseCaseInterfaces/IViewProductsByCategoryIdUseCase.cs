using EntitiesLayer;

namespace UseCasesLayer.Interfaces.ProductsUseCaseInterfaces
{
    public interface IViewProductsByCategoryIdUseCase
    {
        IEnumerable<Product> Execute(int categoryId);
    }
}