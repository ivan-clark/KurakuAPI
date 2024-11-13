using DataAccess.Entities;
using KurakuAPI.Models;

namespace KurakuAPI.Services.Interfaces;

public interface IActivityService
{
    public IQueryable<ActivityModel> GetActivities();
}
