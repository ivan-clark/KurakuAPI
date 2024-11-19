using DataAccess.Entities;

namespace KurakuAPI.Models;

public class FlightModel
{
    public long Id { get; set; }

    public string AirLine { get; set; }

    public string FlightNumber { get; set; }

    public DateTime DepartureTime { get; set; }

    public DateTime ArrivalTime { get; set; }

    public string FromLocation { get; set; }

    public string ToLocation { get; set; }

    public long ItineraryId { get; set; }

    public Itinerary? Itinerary { get; set; }
}
