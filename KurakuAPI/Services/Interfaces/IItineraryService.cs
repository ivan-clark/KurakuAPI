using KurakuAPI.Models;

namespace KurakuAPI.Services.Interfaces;

public interface IItineraryService
{
    public IQueryable<ItineraryModel> GetItineraries();
}
