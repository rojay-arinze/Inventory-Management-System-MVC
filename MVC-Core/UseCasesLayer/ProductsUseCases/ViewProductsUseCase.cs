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
    public class ViewProductsUseCase : IViewProductsUseCase
    {
        private readonly IProductsRepository _productsRepository;

        public ViewProductsUseCase(IProductsRepository productsRepository)
        {
            this._productsRepository = productsRepository;
        }
        public IEnumerable<Product> Execute(bool loadCategory=false)
        {
            return _productsRepository.GetProducts(loadCategory);
        }


    }
}
