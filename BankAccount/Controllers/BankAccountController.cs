using System.Security.Claims;
using BankAccount.Data.Dtos;
using BankAccount.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankAccount.Controllers;

[ApiController]
[Route("[controller]")]
public class BankAccountController:ControllerBase
{
    private readonly IBankAccountRepository _bankAccountRepository;
    public BankAccountController(IBankAccountRepository bankAccountRepository)
    {
        _bankAccountRepository = bankAccountRepository;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetInfoAccount([FromQuery]int acountId )
    {
        var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var account = await _bankAccountRepository.GetBankAccount(user,acountId);
        return Ok("Su Saldo actual es: " + account.Amount);
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateBankAccount([FromBody] CreateBankAccountDto bankAccountDto)
    {
        var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var response =await _bankAccountRepository.CreateBankAccount(user,bankAccountDto);

        return Ok(response);
    }
    
    [HttpPut]
    [Authorize]
    public async Task<IActionResult> UpdateBankAccountAmount([FromQuery]int tipoOperacion ,[FromBody] UpdateBankAccountAmmountDto updateBankAccountAmmountDto)
    {
        var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var response = await _bankAccountRepository.UpdateBankAccount(user, tipoOperacion,updateBankAccountAmmountDto);
        return Ok(response);
    }

    
}