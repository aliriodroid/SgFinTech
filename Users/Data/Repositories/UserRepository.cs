using Microsoft.EntityFrameworkCore;
using User.Data.Dtos;
using User.Data.Entities;

namespace User.Data.Repositories;

public class UserRepository:IUserRepository
{
    private readonly DataContext _dbContext;

    public UserRepository(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserProfileResponseDto> GetUserProfile(string id)
    {
        var userProfile = await _dbContext.UserProfiles.FirstOrDefaultAsync(x=>x.UserId == id);
        var response = new UserProfileResponseDto(userProfile.NickName);
        return response;
    }
    
    public async Task CreateUserProfile(CreateUserProfileDto userDto,string id)
    {
        var userProfile = new UserProfile()
        {
            NickName = userDto.NickName,
            UserId = id
        };
        var createUser = await _dbContext.UserProfiles.AddAsync(userProfile);

        await _dbContext.SaveChangesAsync();

    }

}