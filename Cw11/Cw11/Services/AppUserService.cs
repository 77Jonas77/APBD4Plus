using Cw11.Contexts;
using Cw11.Exceptions;
using Cw11.Helpers;
using Cw11.Models;
using Cw11.Models.DbModels;
using Cw11.Models.Responses;
using Cw11.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Cw11.Services;

public class AppUserService(AppDbContext context) : IAppUserService
{
    public async Task RegisterNewUserAsync(string username, string passwordSaltHash, string salt)
    {
        // uniqueness
        await IsUsernameUniqueAsync(username);
        await AddUserWithHashedToDbAsync(username, passwordSaltHash, salt);
    }

    private async Task AddUserWithHashedToDbAsync(string username, string passwordSaltHash, string salt)
    {
        await context.Users.AddAsync(new AppUser
        {
            Login = username,
            Password = passwordSaltHash,
            Salt = salt
        });
        await context.SaveChangesAsync();
    }

    private async Task IsUsernameUniqueAsync(string username)
    {
        var user = await context.Users.Where(e => e.Login == username).FirstOrDefaultAsync();
        if (user is not null)
        {
            throw new BadRequestException("Username already exists");
        }
    }

    public async Task<AppUser> GetUserByUsernameAsync(string username)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Login == username);
        if (user is null)
        {
            throw new BadRequestException("No user with username provided! : " + username);
        }

        return user;
    }

    public async Task<AppUser> GetUserByIdAsync(int id)
    {
        var user = await context.Users.Where(u => u.IdUser == id).FirstOrDefaultAsync();
        if (user is null) throw new UnauthorizedException("Unauthorized!");

        return user;
    }

    public Task<bool> IsUserLoginPasswordCompatible(AppUser user, string password)
    {
        string passwordHashFromDb = user.Password;
        string curHashedPassword = SecurityHelpers.GetHashedPasswordWithSalt(password, user.Salt);
        Console.WriteLine(passwordHashFromDb + " " + curHashedPassword);
        if (passwordHashFromDb != curHashedPassword)
        {
            return Task.FromResult(false);
        }

        return Task.FromResult(true);
    }

    Task IAppUserService.AddNewRefreshToken(AppUser user, string refToken)
    {
        return AddNewRefreshToken(user, refToken);
    }

    public async Task<AppUser> GetUserByRefreshToken(string refToken)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.RefreshToken == refToken);
        if (user == null)
        {
            throw new SecurityTokenException("Invalid refresh token");
        }

        return user;
    }

    public async Task<IEnumerable<AppUser>?> GetUsers()
    {
        var users = await context.Users.ToListAsync();
        return users;
    }

    public async Task AddNewRefreshToken(AppUser user, string refToken)
    {
        user.RefreshToken = refToken;
        await context.SaveChangesAsync();
    }
}