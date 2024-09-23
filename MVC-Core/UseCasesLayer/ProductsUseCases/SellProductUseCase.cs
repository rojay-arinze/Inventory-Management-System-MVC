using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCasesLayer.DataStorePluginInterfaces;
using UseCasesLayer.Interfaces.ProductsUseCaseInterfaces;
using UseCasesLayer.Interfaces.TransactionsUseCaseInterfaces;

namespace UseCasesLayer.ProductsUseCases
{
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IProductsRepository productsRepository;
        private readonly IRecordTransactionUseCase recordTransactionUseCase;

        public SellProductUseCase(IProductsRepository productsRepository,
                                 IRecordTransactionUseCase recordTransactionUseCase)
        {
            this.productsRepository = productsRepository;
            this.recordTransactionUseCase = recordTransactionUseCase;
        }

        public void Execute(string cashierName, int productId, int qtyToSell)
        {
            var product = productsRepository.GetProductById(productId);
            if (product == null)
            {
                return;
            }
            recordTransactionUseCase.Execute(cashierName, productId, qtyToSell);
            product.Quantity -= qtyToSell;
            productsRepository.UpdateProduct(productId, product);
        }
    }
}
