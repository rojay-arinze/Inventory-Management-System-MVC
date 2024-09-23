using Microsoft.AspNetCore.Mvc;
using UseCasesLayer.Interfaces.TransactionsUseCaseInterfaces;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ISearchTransactionsUseCase searchTransactionsUseCase;

        public TransactionsController(ISearchTransactionsUseCase searchTransactionsUseCase)
        {
            this.searchTransactionsUseCase = searchTransactionsUseCase;
        }
        public IActionResult Index()
        {
            var transactionsViewModel = new TransactionsViewModel();
            return View(transactionsViewModel);
        }

        public IActionResult Search(TransactionsViewModel transactionsViewModel) 
        {
            var transactions =searchTransactionsUseCase.Execute(
                transactionsViewModel.CashierName ?? string.Empty,
                transactionsViewModel.StartDate,
                transactionsViewModel.EndDate
                );

            transactionsViewModel.Transactions = transactions;
            return View("Index", transactionsViewModel);
        }
    }
}
