using BankingApp.Core.Interfaces;
using BankingApp.Core.Models;

namespace BankingApp.Core.Services;


public class TransactionService : ITransactionService
{
    private readonly ISqlDataAccess _db;

    public TransactionService(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<TransactionModel>> GetTransactionsByAccountIdAsync(int accountId)
    {
        return await _db.LoadData<TransactionModel, dynamic>(
            "SELECT * FROM sptransactions_getbyaccountid(@AccountId)",
            new { AccountId = accountId });
    }

    public async Task<IEnumerable<TransactionModel>> GetAllTransactionsAsync()
    {
        return await _db.LoadData<TransactionModel, dynamic>(
            "SELECT * FROM sptransactions_getall()", new { });
    }

    public async Task CreateTransactionAsync(TransactionModel transaction)
    {
        await _db.SaveData(
            "SELECT sptransactions_insert(@AccountId, @Amount, @Type, @Description, @TransactionDate)",
            new
            {
                transaction.AccountId,
                transaction.Amount,
                transaction.Type,
                transaction.Description,
                transaction.TransactionDate
            });
    }

    public async Task UpdateTransactionAsync(TransactionModel transaction)
    {
        await _db.SaveData(
            "SELECT sptransactions_update(@Id, @AccountId, @Amount, @Type, @Description, @TransactionDate)",
            new
            {
                transaction.Id,
                transaction.AccountId,
                transaction.Amount,
                transaction.Type,
                transaction.Description,
                transaction.TransactionDate
            });
    }
}