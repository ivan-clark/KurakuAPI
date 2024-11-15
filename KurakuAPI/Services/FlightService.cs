using DataAccess;
using DataAccess.Entities;
using KurakuAPI.Models;
using KurakuAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KurakuAPI.Services;

public class FlightService(ApplicationDbContext dbContext) : IFlightService
{
    public Flight GetFlightById (long id)
    {
        return dbContext.Flights.FirstOrDefault(i => i.Id == id);
    }

    public IQueryable<FlightModel> GetFlights ()
    {
        return dbContext.Flights
            .Include(a => a.Itinerary)
            .Select(a => new FlightModel
        {
            Id = a.Id,
            AirLine = a.Airline,
            FlightNumber = a.FlightNumber,
            DepartureTime = a.DepartureTime,
            ArrivalTime = a.ArrivalTime,
            FromLocation = a.FromLocation,
            ToLocation = a.ToLocation,
        });
    }

    public void CreateFlights(FlightModel model)
    {
        var flights = new Flight
        {
            Id = model.Id,
            Airline = model.AirLine,
            FlightNumber = model.FlightNumber,
            DepartureTime = model.DepartureTime,
            ArrivalTime = model.ArrivalTime,
            FromLocation = model.FromLocation,
            ToLocation = model.ToLocation,
            ItineraryId = model.ItineraryId,
        };

        dbContext.Flights.Add(flights);
        dbContext.SaveChanges();
    }

    public void UpdateFlights (FlightModel model)
    {
        var flights = dbContext.Flights.SingleOrDefault(a => a.Id == model.Id);

        if (flights != null)
        {
            flights.Airline = model.AirLine ?? flights.Airline;
            flights.FlightNumber = model.FlightNumber ?? flights.FlightNumber;
            flights.DepartureTime = model.DepartureTime;
            flights.ArrivalTime = model.ArrivalTime;
            flights.FromLocation = model.FromLocation ?? flights.FromLocation;
            flights.ToLocation = model.ToLocation ?? flights.ToLocation;
            flights.ItineraryId = model.ItineraryId;

            dbContext.SaveChanges();
        }
    }

    public void DeleteFlights (long id)
    {
        var flights = dbContext.Flights.SingleOrDefault(a => a.Id == id);

        dbContext.Attach(flights);
        dbContext.Remove(flights);
        dbContext.SaveChanges();
    }
}
