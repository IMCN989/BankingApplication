using BankingApp.Core.Models;

public interface IAccountService
{
    Task<int> CreateAccountAsync(AccountModel account);
    Task<bool> DeleteAccountAsync(int id);
    Task<AccountModel?> GetAccountByIdAsync(int id);
    Task<IEnumerable<AccountModel>> GetAccountsAsync(int? userId = null);
    Task<bool> UpdateAccountAsync(AccountModel account);
}