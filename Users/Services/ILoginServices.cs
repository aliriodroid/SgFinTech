

namespace User.Services;

public interface ILoginService
{
    public string GenerateToken(string userId,string email);
}