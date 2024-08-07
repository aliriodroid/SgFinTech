using BankAccount.Data.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BankAccount.Data.Repositories;

public class BankAccountRepository:IBankAccountRepository
{
    private readonly DataContext _dbContext;

    public BankAccountRepository(DataContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Entities.BankAccount> CreateBankAccount(string userId,CreateBankAccountDto bankAccountDto)
    {
        try
        {
            Random cbuGenerator = new Random();
            Entities.BankAccount account = new Entities.BankAccount()
            {
                UserId = userId,
                Currency = bankAccountDto.CurrencyId,
                Amount = bankAccountDto.Amount,
                Cbu = cbuGenerator.Next(),
                Status = 1
            };
            var newAccount = await _dbContext.BankAccounts.AddAsync(account);

            await _dbContext.SaveChangesAsync();
            
            return newAccount.Entity;
        }
        catch (Exception e)
        {
            throw new ($"Error inesperado al intentar crear la cuenta", e);
        }
    }
    
    public async Task<BankAccountDto> GetBankAccount(string userId,int id)
    {
        try
        {
            var bankAccount = await _dbContext.BankAccounts.FirstOrDefaultAsync(x=>x.UserId==userId && x.Id==id);
            if (bankAccount is null)
            {
                throw new Exception("La cuenta no existe para este usuario");
            }
            var response = new BankAccountDto(bankAccount.UserId,bankAccount.Id, bankAccount.Currency, bankAccount.Amount,
                bankAccount.Status);
            
            return response;
        }
        catch (Exception e)
        {
            throw new ($"Error inesperado al intentar obtener la cuenta con ID: {id}", e);
        }

    }
    
    public async Task<string> UpdateBankAccount(string userId, int tipoOperacion, UpdateBankAccountAmmountDto bankAccountDto)
    {
        try
        {
            var bankAccount = await _dbContext.BankAccounts.FirstOrDefaultAsync(x=>x.UserId==userId && x.Id==bankAccountDto.accountId);

            if (bankAccount is not null)
            {
                
                if (tipoOperacion == 010 && bankAccount.Amount - bankAccountDto.Amount < 0)
                {
                    return ("Su saldo es insuficiente." + bankAccount.Amount);
                }
                
                if (tipoOperacion == 001)
                {
                    bankAccount.Amount =bankAccount.Amount + bankAccountDto.Amount;
                }
                else if(tipoOperacion == 010)
                {
                    bankAccount.Amount =bankAccount.Amount - bankAccountDto.Amount;

                }
                else
                { 
                    return("Tipo de operacion no valida.");
                }
                
            }
            else
            {
                throw new Exception("La cuenta no existe");
            }

            var response = new BankAccountDto(bankAccount.UserId, bankAccount.Currency,bankAccount.Id, bankAccount.Amount,
                bankAccount.Status);

            await _dbContext.SaveChangesAsync();

            return "Su saldo actual es: "+response.Amount;
        }
        catch (Exception e)
        {
            throw new ($"Error inesperado al actualizar la cuenta con ID: {userId}", e);
        }

    }

}