using EntitiesLayer;
using Microsoft.EntityFrameworkCore;
using Plugins.DataStore.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Plugins.DataStore.SQLServer
{
    public class TransactionSQLRepository:ITransactionsRepository
    {
        private readonly MarketContext db;

        public TransactionSQLRepository(MarketContext db)
        {
            this.db = db;
        }

        public void Add(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty)
        {
            var transaction = new Transaction 
            {
                CashierName = cashierName,
                ProductId = productId,  
                ProductName = productName,
                Price = price,
                BeforeQty = beforeQty,
                SoldQty = soldQty,
                TimeStamp = DateTime.Now
            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

        public IEnumerable<Transaction> GetByDayAndCashier(string cashierName, DateTime date)
        {
            if(string.IsNullOrWhiteSpace(cashierName))
            {
                return db.Transactions
                    .Where(x => x.TimeStamp.Date == date);
            }
            else
            {
                return db.Transactions
                    .Where(x => EF.Functions.Like(x.CashierName, $"%{cashierName}%") &&
                    x.TimeStamp.Date == date.Date);

            }
        }

        public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
            {
                return db.Transactions
                    .Where(x => x.TimeStamp.Date >= startDate.Date && x.TimeStamp <= endDate.Date);
            }
            else
            {
                return db.Transactions
                    .Where(x => EF.Functions.Like(x.CashierName, $"%{cashierName}%") &&
                    x.TimeStamp.Date >= startDate.Date && x.TimeStamp <= endDate.Date);

            }
        }
    }
}
