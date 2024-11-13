using DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

namespace KurakuAPI.Models;

public class ItineraryModel
{
    public long Id { get; set; }

    public string Destination { get; set; }

    public string UserId { get; set; }

    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

}
