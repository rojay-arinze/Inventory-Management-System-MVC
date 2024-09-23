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
    public class GetTodayTransactionsUseCase : IGetTodayTransactionsUseCase
    {
        private readonly ITransactionsRepository transactionsRepository;

        public GetTodayTransactionsUseCase(ITransactionsRepository transactionsRepository)
        {
            this.transactionsRepository = transactionsRepository;
        }
        public IEnumerable<Transaction> Execute(string cashierName)
        {
            return transactionsRepository.GetByDayAndCashier(cashierName, DateTime.Now);
        }
    }
}
