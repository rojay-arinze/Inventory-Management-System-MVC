namespace WebApp.Models
{
    public class TransactionsRepository
    {
        private static List<Transaction> _transactions = new List<Transaction>();

        public static IEnumerable<Transaction> GetByDayAndCashier(string cashierName, DateTime date) 
        { 
            if(string.IsNullOrWhiteSpace(cashierName))
            {
                return _transactions.Where(x => x.TimeStamp.Date == date.Date);

            }
            else
            {
                return _transactions.Where(x =>
                    x.CashierName.ToLower().Contains(cashierName.ToLower()) &&
                    x.TimeStamp.Date == date.Date);
            }
        }

        public static IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
        {
            if(string.IsNullOrWhiteSpace(cashierName))
            {
                return _transactions.Where(x =>
                    x.TimeStamp.Date >= startDate.Date && x.TimeStamp.Date <= endDate.Date.AddDays(1).Date);
            }
            else
            {
                return _transactions.Where(x =>
                    x.CashierName.ToLower().Contains(cashierName.ToLower())&&
                    x.TimeStamp.Date >= startDate.Date &&
                    x.TimeStamp.Date <= endDate.Date.AddDays(1).Date);
            }
        }

        public static void Add(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty)
        {
            var transaction = new Transaction()
            {
                ProductId = productId,
                ProductName = productName,
                Price = price,
                BeforeQty = beforeQty,
                SoldQty = soldQty,
                CashierName = cashierName,
                TimeStamp = DateTime.Now.Date
            };

            if (_transactions != null && _transactions.Count()>0) 
            {
                var maxId = _transactions.Max(x => x.TransactionId);
                transaction.TransactionId = maxId +1;
            }
            else
            {
                transaction.TransactionId = 1;
            }
            _transactions?.Add(transaction);
        }
    }
}
