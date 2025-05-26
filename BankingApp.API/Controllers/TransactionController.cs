using BankingApp.Core.Interfaces;
using BankingApp.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    // GET: api/transaction
    [HttpGet]
    public async Task<IActionResult> GetAllTransactions()
    {
        var transactions = await _transactionService.GetAllTransactionsAsync();
        return Ok(transactions);
    }

    // GET: api/transaction/account/5
    [HttpGet("account/{accountId}")]
    public async Task<IActionResult> GetByAccountId(int accountId)
    {
        var transactions = await _transactionService.GetTransactionsByAccountIdAsync(accountId);
        return Ok(transactions);
    }

    // POST: api/transaction
    [HttpPost]
    public async Task<IActionResult> CreateTransaction([FromBody] TransactionModel transaction)
    {
        if (transaction == null)
            return BadRequest("Transaction data is required.");

        await _transactionService.CreateTransactionAsync(transaction);
        return Created("", transaction); // optionally return CreatedAtAction
    }

    // PUT: api/transaction/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTransaction(int id, [FromBody] TransactionModel transaction)
    {
        if (transaction == null || transaction.Id != id)
            return BadRequest("Invalid transaction data.");

        await _transactionService.UpdateTransactionAsync(transaction);
        return NoContent();
    }
}

