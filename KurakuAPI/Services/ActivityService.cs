using DataAccess;
using DataAccess.Entities;
using KurakuAPI.Models;
using KurakuAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KurakuAPI.Services;

public class ActivityService(ApplicationDbContext dbContext) : IActivityService
{
    public IQueryable<ActivityModel> GetActivities()
    {
        return dbContext.Activities
            .Include(a => a.Itinerary)
            .Select(a => new ActivityModel
        {
            Id = a.Id,
            Name = a.Name,
            Description = a.Description,
        });
    }
}
