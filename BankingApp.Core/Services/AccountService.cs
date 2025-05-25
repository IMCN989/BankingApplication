using BankingApp.Core.Interfaces;
using BankingApp.Core.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IDbConnection _db;

        public AccountService(IConfiguration config)
        {
            _db = new NpgsqlConnection(config.GetConnectionString("DefaultConnection"));
        }

        public async Task<IEnumerable<Account>> GetAccountsAsync(int? userId = null)
        {
            var sql = userId.HasValue
                ? "SELECT * FROM get_accounts_by_user(@UserId)"
                : "SELECT * FROM get_all_accounts()";
            return await _db.QueryAsync<Account>(sql, new { UserId = userId });
        }

        public async Task<Account> GetAccountByIdAsync(int id)
        {
            var sql = "SELECT * FROM accounts WHERE id = @Id";
            return await _db.QueryFirstOrDefaultAsync<Account>(sql, new { Id = id });
        }

        public async Task<int> CreateAccountAsync(Account account)
        {
            var sql = "SELECT create_account(@UserId, @AccountNumber, @Balance, @AccountType)";
            return await _db.ExecuteScalarAsync<int>(sql, account);
        }

        public async Task<bool> UpdateAccountAsync(Account account)
        {
            var sql = "SELECT update_account(@Id, @AccountNumber, @Balance, @AccountType)";
            return await _db.ExecuteScalarAsync<bool>(sql, account);
        }

        public async Task<bool> DeleteAccountAsync(int id)
        {
            var sql = "SELECT delete_account(@Id)";
            return await _db.ExecuteScalarAsync<bool>(sql, new { Id = id });
        }
    }

}
