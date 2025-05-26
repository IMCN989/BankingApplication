using BankingApp.Core.Models;

namespace BankingApp.Core.Interfaces
{
    public interface ITransactionService
    {
        Task CreateTransactionAsync(TransactionModel transaction);
        Task<IEnumerable<TransactionModel>> GetAllTransactionsAsync();
        Task<IEnumerable<TransactionModel>> GetTransactionsByAccountIdAsync(int accountId);
        Task UpdateTransactionAsync(TransactionModel transaction);
    }
}