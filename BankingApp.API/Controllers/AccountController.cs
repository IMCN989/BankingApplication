using Microsoft.AspNetCore.Mvc;
using BankingApp.Core.Interfaces;
using BankingApp.Core.Models;

namespace BankingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // GET: api/account
        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            var accounts = await _accountService.GetAccountsAsync();
            return Ok(accounts);
        }

        // POST: api/account
        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] Account account)
        {
            if (account == null)
                return BadRequest("Account data is required.");

            var newId = await _accountService.CreateAccountAsync(account);

            if (newId <= 0)
                return StatusCode(500, "Failed to create account.");

            account.Id = newId;
            return CreatedAtAction(nameof(GetAllAccounts), new { id = newId }, account);
        }
    }
}
