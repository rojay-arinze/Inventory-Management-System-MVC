﻿namespace UseCasesLayer.Interfaces.TransactionsUseCaseInterfaces
{
    public interface IRecordTransactionUseCase
    {
        void Execute(string cashierName, int productId, int qty);
    }
}