using EntitiesLayer;

namespace UseCasesLayer.Interfaces.CategoriesUseCaseInterfaces
{
    public interface IViewSelectedCategoryUseCase
    {
        Category? Execute(int categoryId);
    }
}