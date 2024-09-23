using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCasesLayer.DataStorePluginInterfaces;
using UseCasesLayer.Interfaces.ProductsUseCaseInterfaces;

namespace UseCasesLayer.ProductsUseCases
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IProductsRepository _productsRepository;

        public DeleteProductUseCase(IProductsRepository productsRepository)
        {
            this._productsRepository = productsRepository;
        }
        public void Execute(int productID)
        {
            _productsRepository.DeleteProduct(productID);
        }
    }
}
