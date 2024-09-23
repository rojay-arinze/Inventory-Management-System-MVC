using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCasesLayer.DataStorePluginInterfaces;
using UseCasesLayer.Interfaces.ProductsUseCaseInterfaces;

namespace UseCasesLayer.ProductsUseCases
{
    public class ViewProductsByCategoryIdUseCase : IViewProductsByCategoryIdUseCase
    {
        private readonly IProductsRepository _productsRepository;

        public ViewProductsByCategoryIdUseCase(IProductsRepository productsRepository)
        {
            this._productsRepository = productsRepository;
        }
        public IEnumerable<Product> Execute(int categoryId)
        {
            return _productsRepository.GetProductsByCategoryId(categoryId);
        }
    }
}
