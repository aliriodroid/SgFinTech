using Microsoft.AspNetCore.Identity;

namespace User.Data.Entities;

public class UserProfile
{
    public int Id { get; set; }
    public string NickName { get; set; }
    public string UserId { get; set; }
    public virtual IdentityUser User { get; set; }
}