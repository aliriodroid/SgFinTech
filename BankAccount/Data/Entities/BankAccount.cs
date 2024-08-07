namespace BankAccount.Data.Entities;
public class BankAccount
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public int Currency { get; set; }
    public decimal Amount { get; set; }
    public int Cbu { get; set; }
    public int Status { get; set; }
    public DateTime CreatedAt { get; set; } 
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}