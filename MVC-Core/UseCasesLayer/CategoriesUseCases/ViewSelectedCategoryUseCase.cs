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
    public class ViewSelectedCategoryUseCase : IViewSelectedCategoryUseCase
    {
        private readonly ICategoryRepository _categoryRepository;

        public ViewSelectedCategoryUseCase(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }
        public Category? Execute(int categoryId)
        {
            return _categoryRepository.GetCategoryById(categoryId);
        }
    }
}
