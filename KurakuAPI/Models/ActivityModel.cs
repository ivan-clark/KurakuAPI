using DataAccess.Entities;

namespace KurakuAPI.Models;

public class ActivityModel
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public Itinerary? Itinerary { get; set; }
}
