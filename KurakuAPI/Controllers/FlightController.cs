using KurakuAPI.Models;
using KurakuAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.Mvc;
using KurakuAPI.Services;
using Microsoft.EntityFrameworkCore;
using DataAccess;

namespace KurakuAPI.Controllers;

[Authorize]
public class FlightController(IFlightService flightService, IItineraryService itineraryService, ApplicationDbContext dbContext) : ODataController
{
    [EnableQuery]
    public IQueryable<FlightModel> Get()
    {
        return flightService.GetFlights();
    }

    [HttpPost("api/Flight/CreateFlight")]
    public IActionResult CreateFlight ([FromBody]FlightModel model)
    {
        try
        {
            var itinerary = itineraryService.GetItineraryById(model.Itinerary.Id);

            if (itinerary == null)
            {
                return BadRequest("The ItineraryId provided does not exist.");
            }

            flightService.CreateFlights(model);
            return Ok("Flight created successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("api/Flight/UpdateFlight/{id}")]
    public IActionResult UpdateFlight (long id,[FromBody] FlightModel model)
    {
        try
        {
            if (model == null || id != model.Id)
            {
                return BadRequest("Invalid flight data");
            }

            var flightUpdate = flightService.GetFlightById(id);
            if (flightUpdate == null)
            {
                return NotFound($"Flight with Id = {id} not found.");
            }

            flightService.UpdateFlights(model);
            return Ok("Flight updated successfully");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("api/Flight/DeleteFlight/{id}")]
    public IActionResult DeleteFlight (long id)
    {
        try
        {
            var flight = flightService.GetFlightById(id);
            if (flight == null)
            {
                return NotFound($"Flight with Id = {id} not found.");
            }

            flightService.DeleteFlights(id);
            return Ok($"Flight with an Id of = {id} has been deleted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
