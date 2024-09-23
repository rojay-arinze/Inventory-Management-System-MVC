using EntitiesLayer;

namespace UseCasesLayer.Interfaces.TransactionsUseCaseInterfaces
{
    public interface IGetTodayTransactionsUseCase
    {
        IEnumerable<Transaction> Execute(string cashierName);
    }
}