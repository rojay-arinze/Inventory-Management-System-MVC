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
    public class EditProductUseCase : IEditProductUseCase
    {
        private readonly IProductsRepository _productsInMemoryRepository;

        public EditProductUseCase(IProductsRepository productsInMemoryRepository)
        {
            this._productsInMemoryRepository = productsInMemoryRepository;
        }
        public void Execute(int productId, Product product)
        {
            _productsInMemoryRepository.UpdateProduct(productId, product);
        }
    }
}
