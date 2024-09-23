using Plugins.DataStore.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCasesLayer.DataStorePluginInterfaces;
using UseCasesLayer.Interfaces.TransactionsUseCaseInterfaces;

namespace UseCasesLayer.TransactionsUseCases
{
    public class RecordTransactionUseCase : IRecordTransactionUseCase
    {
        private readonly ITransactionsRepository transactionsRepository;
        private readonly IProductsRepository productsRepository;

        public RecordTransactionUseCase(ITransactionsRepository transactionsRepository,
                                        IProductsRepository productsRepository)
        {
            this.transactionsRepository = transactionsRepository;
            this.productsRepository = productsRepository;
        }

        public void Execute(string cashierName, int productId, int qty)
        {
            var product = productsRepository.GetProductById(productId);
            if (product != null)
            {
                transactionsRepository.Add(
                    cashierName,
                    productId,
                    product.Name,
                    product.Price.HasValue ? product.Price.Value : 0,
                    product.Quantity.HasValue ? product.Quantity.Value : 0,
                    qty
                    );
            }
        }
    }
}
