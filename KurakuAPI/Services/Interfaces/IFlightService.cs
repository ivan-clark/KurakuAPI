using DataAccess.Entities;
using KurakuAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace KurakuAPI.Services.Interfaces;

public interface IFlightService
{
    public Flight GetFlightById(long id);
    public IQueryable<FlightModel> GetFlights();

    public void CreateFlights(FlightModel model);

    public void UpdateFlights(FlightModel model);

    public void DeleteFlights(long id);
}
