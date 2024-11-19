using DataAccess;
using KurakuAPI.Models;
using KurakuAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KurakuAPI.Services;

public class AccomodationService(ApplicationDbContext dbContext) : IAccomodationService
{
    public IQueryable<AccomodationModel> GetAccomodations()
    {
        return dbContext.Accomodations
            .Include(a => a.Itinerary)
            .Select(a => new AccomodationModel
        {
            Id = a.Id,
            HotelName = a.HotelName,
            Address = a.Address,
            CheckInDate = a.CheckInDate,
            CheckOutDate = a.CheckOutDate,
        });
    }
}
