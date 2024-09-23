using EntitiesLayer;

namespace UseCasesLayer.Interfaces.TransactionsUseCaseInterfaces
{
    public interface ISearchTransactionsUseCase
    {
        IEnumerable<Transaction> Execute(string cashierName, DateTime startDate, DateTime endDate);
    }
}