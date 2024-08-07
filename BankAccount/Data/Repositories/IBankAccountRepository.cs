using BankAccount.Data.Dtos;

namespace BankAccount.Data.Repositories;

public interface IBankAccountRepository
{
    public Task<BankAccountDto> GetBankAccount(string userId,int id);
    public Task<Entities.BankAccount> CreateBankAccount(string userId,CreateBankAccountDto bankAccountDto);
    public Task<string> UpdateBankAccount(string userId, int tipoOperacion, UpdateBankAccountAmmountDto bankAccountDto);
}