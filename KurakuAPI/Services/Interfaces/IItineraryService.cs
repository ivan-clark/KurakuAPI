using DataAccess.Entities;
using KurakuAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KurakuAPI.Services.Interfaces;

public interface IItineraryService
{
    public Itinerary GetItineraryById(long itineraryId);

    public IQueryable<ItineraryModel> GetItineraries();
}
