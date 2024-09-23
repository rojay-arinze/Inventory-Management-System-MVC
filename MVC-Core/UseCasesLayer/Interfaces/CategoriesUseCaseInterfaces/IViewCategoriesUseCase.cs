using EntitiesLayer;

namespace UseCasesLayer.Interfaces.CategoriesUseCaseInterfaces
{
    public interface IViewCategoriesUseCase
    {
        IEnumerable<Category> Execute();
    }
}