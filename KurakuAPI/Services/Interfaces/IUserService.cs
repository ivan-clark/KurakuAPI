using KurakuAPI.Models;

namespace KurakuAPI.Services.Interfaces;

public interface IUserService
{
    IQueryable<UserModel> GetUsers();
}
