using KurakuAPI.Models;

namespace KurakuAPI.Services.Interfaces;

public interface IAccomodationService
{
    public IQueryable<AccomodationModel> GetAccomodations();
}
