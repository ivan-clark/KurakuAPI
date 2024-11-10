using KurakuAPI.Models;

namespace KurakuAPI.Services.Interfaces;

public interface IProfileService
{
    public IQueryable<ProfileModel> GetProfiles();
}
