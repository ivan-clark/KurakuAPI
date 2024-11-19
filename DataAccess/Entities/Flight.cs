using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

public class Flight
{
    [Required]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    public string Airline { get; set; }

    [Required]
    public string FlightNumber {  get; set; }

    [Required]
    public DateTime DepartureTime { get; set; }

    [Required]
    public DateTime ArrivalTime { get; set; }

    [Required]
    public string FromLocation { get; set; }

    [Required]
    public string ToLocation { get; set; }

    [Required]
    [Display(Name = "ItineraryId")]
    public long ItineraryId { get; set; }

    [ForeignKey("ItineraryId")]
    public Itinerary Itinerary { get; set; }

}
