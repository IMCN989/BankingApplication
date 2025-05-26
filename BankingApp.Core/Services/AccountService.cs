using BankingApp.Core.DataAccess;
using BankingApp.Core.Models;
using BankingApp.Core.Interfaces;

public class AccountService : IAccountService
{
    private readonly ISqlDataAccess _db;

    public AccountService(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<AccountModel>> GetAccountsAsync(int? userId = null)
    {
        string sql = userId.HasValue
            ? "SELECT * FROM get_accounts_by_user(@UserId)"
            : "SELECT * FROM get_all_accounts()";

        return await _db.LoadData<AccountModel, dynamic>(sql, new { UserId = userId });
    }

    public async Task<AccountModel?> GetAccountByIdAsync(int id)
    {
        var result = await _db.LoadData<AccountModel, dynamic>(
            "SELECT * FROM accounts WHERE id = @Id", new { Id = id });

        return result.FirstOrDefault();
    }

    public async Task<int> CreateAccountAsync(AccountModel account)
    {
        var sql = "SELECT create_account(@UserId, @AccountNumber, @Balance, @AccountType)";
        return await _db.LoadData<int, AccountModel>(sql, account).ContinueWith(t => t.Result.First());
    }

    public async Task<bool> UpdateAccountAsync(AccountModel account)
    {
        var sql = "SELECT update_account(@Id, @AccountNumber, @Balance, @AccountType)";
        var result = await _db.LoadData<bool, AccountModel>(sql, account);
        return result.FirstOrDefault();
    }

    public async Task<bool> DeleteAccountAsync(int id)
    {
        var sql = "SELECT delete_account(@Id)";
        var result = await _db.LoadData<bool, dynamic>(sql, new { Id = id });
        return result.FirstOrDefault();
    }
}
