using DataAccess;
using DataAccess.Entities;
using KurakuAPI.Models;
using KurakuAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KurakuAPI.Services;

public class ItineraryService(ApplicationDbContext dbContext) : IItineraryService
{
    public Itinerary GetItineraryById (long itineraryId)
    {
        return dbContext.Itineraries.FirstOrDefault(i => i.Id == itineraryId);
    }

    public IQueryable<ItineraryModel> GetItineraries()
    {
        return dbContext.Itineraries
            .Include(a => a.User)
            .Select(a => new ItineraryModel
        {
            Id = a.Id,
            Destination = a.Destination,
            UserId = a.User.Id,
            StartDate = a.StartDate,
            EndDate = a.EndDate,
        });
    }
}
