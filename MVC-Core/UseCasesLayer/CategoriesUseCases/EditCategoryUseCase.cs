using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCasesLayer.DataStorePluginInterfaces;
using UseCasesLayer.Interfaces.CategoriesUseCaseInterfaces;

namespace UseCasesLayer.CategoriesUseCases
{
    public class EditCategoryUseCase : IEditCategoryUseCase
    {
        private readonly ICategoryRepository _categoryRepository;

        public EditCategoryUseCase(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }
        public void Execute(int categoryId, Category category)
        {
            _categoryRepository.UpdateCategory(categoryId, category);
        }
    }
}
