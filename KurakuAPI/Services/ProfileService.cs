using DataAccess;
using KurakuAPI.Models;
using KurakuAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KurakuAPI.Services;

public class ProfileService(ApplicationDbContext dbContext) : IProfileService
{

    public IQueryable<ProfileModel> GetProfiles()
    {
        return dbContext.Profiles
            .Include(p => p.User)
            .Select(p => new ProfileModel
        {
            Id = p.Id,
            FirstName = p.FirstName,
            LastName = p.LastName,
            Address = p.Address,
            BirthDate = p.BirthDate,
            Email = p.User.Email ?? "",
            PhoneNumber = p.User.PhoneNumber ?? "",
        });
    }
}
