using DataAccess;
using KurakuAPI.Models;
using KurakuAPI.Services.Interfaces;

namespace KurakuAPI.Services;

public class UserService(ApplicationDbContext dbContext) : IUserService
{
    public IQueryable<UserModel> GetUsers()
    {
        return dbContext.User.Select(u => new UserModel
        {
            Id = u.Id,
            FirstName = u.FirstName,
            MiddleName = u.MiddleName,
            LastName = u.LastName,
            Email = u.Email,
            BirthDate = u.BirthDate
        });
    }
}
