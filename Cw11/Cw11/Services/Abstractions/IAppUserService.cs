using System.Runtime.InteropServices;
using Cw11.Models;
using Cw11.Models.DbModels;

namespace Cw11.Services.Abstractions;

public interface IAppUserService
{
    Task RegisterNewUserAsync(string username, string passwordSaltHash, string salt);
    Task<AppUser> GetUserByUsernameAsync(string username);
    Task<AppUser> GetUserByIdAsync(int id);
    Task<bool> IsUserLoginPasswordCompatible(AppUser user, string password);

    Task AddNewRefreshToken(AppUser user, string refToken);

    Task<AppUser> GetUserByRefreshToken(string refToken);
    Task<IEnumerable<AppUser>?> GetUsers();
}