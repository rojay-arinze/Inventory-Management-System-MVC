using EntitiesLayer;

namespace UseCasesLayer.Interfaces.CategoriesUseCaseInterfaces
{
    public interface IAddCategoryUseCase
    {
        void Execute(Category category);
    }
}