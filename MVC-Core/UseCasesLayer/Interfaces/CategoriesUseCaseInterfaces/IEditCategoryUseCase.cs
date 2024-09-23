using EntitiesLayer;

namespace UseCasesLayer.Interfaces.CategoriesUseCaseInterfaces
{
    public interface IEditCategoryUseCase
    {
        void Execute(int categoryId, Category category);
    }
}