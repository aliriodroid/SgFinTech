namespace BankAccount.Data.Dtos;

public record BankAccountDto(string UserId, int accountId, int CurrencyId, decimal Amount,int Status);
