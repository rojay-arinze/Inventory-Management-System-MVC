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
    public class ViewSelectedProductUseCase : IViewSelectedProductUseCase
    {
        private readonly IProductsRepository _productsRepository;

        public ViewSelectedProductUseCase(IProductsRepository productsRepository)
        {
            this._productsRepository = productsRepository;
        }
        public Product? Execute(int productId)
        {
            return _productsRepository.GetProductById(productId);
        }
    }
}
