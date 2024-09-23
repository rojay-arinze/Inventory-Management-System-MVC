using EntitiesLayer;
using Plugins.DataStore.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCasesLayer.Interfaces.TransactionsUseCaseInterfaces;

namespace UseCasesLayer.TransactionsUseCases
{
    public class SearchTransactionsUseCase : ISearchTransactionsUseCase
    {
        private readonly ITransactionsRepository transactionsRepository;

        public SearchTransactionsUseCase(ITransactionsRepository transactionsRepository)
        {
            this.transactionsRepository = transactionsRepository;
        }
        public IEnumerable<Transaction> Execute(
            string cashierName,
            DateTime startDate,
            DateTime endDate
            )
        {
            return transactionsRepository.Search(cashierName, startDate, endDate);
        }
    }
}
