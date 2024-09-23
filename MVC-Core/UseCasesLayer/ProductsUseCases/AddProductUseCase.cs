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
    public class AddProductUseCase:IAddProductUseCase
    {
        private readonly IProductsRepository _addProductUseCase;

        public AddProductUseCase(IProductsRepository addProductUseCase)
        {
            this._addProductUseCase = addProductUseCase;
        }
        public void Execute(Product product)
        {
            _addProductUseCase.AddProduct(product);
        }
    }
}
