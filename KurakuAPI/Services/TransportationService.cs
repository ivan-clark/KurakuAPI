using DataAccess;
using KurakuAPI.Models;
using KurakuAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KurakuAPI.Services;

public class TransportationService(ApplicationDbContext dbContext) : ITransportationService
{
    public IQueryable<TransportationModel> GetTransportations()
    {
        return dbContext.Transportations
            .Include(a => a.Itinerary)
            .Select(a => new TransportationModel
        {
            Id = a.Id,
            TransportType = a.TransportType,
            Company = a.Company,
            DepartureTime = a.DepartureTime,
            FromLocation = a.FromLocation,
            ToLocation = a.ToLocation,
        });
    }
}
