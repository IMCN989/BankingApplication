using BankingApp.Core.Models;

public interface IAccountService
{
    Task<int> CreateAccountAsync(Account account);
    Task<bool> DeleteAccountAsync(int id);
    Task<Account?> GetAccountByIdAsync(int id);
    Task<IEnumerable<Account>> GetAccountsAsync(int? userId = null);
    Task<bool> UpdateAccountAsync(Account account);
}