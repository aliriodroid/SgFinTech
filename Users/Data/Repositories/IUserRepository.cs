using User.Data.Dtos;

namespace User.Data.Repositories;

public interface IUserRepository
{
    public Task<UserProfileResponseDto> GetUserProfile(string id);
    public Task CreateUserProfile(CreateUserProfileDto userProfile,string id);
}