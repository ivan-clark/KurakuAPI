using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

public class Transportation
{
    [Required]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    public string TransportType { get; set; }

    [Required]
    public string Company { get; set; }

    [Required]
    public DateTime DepartureTime { get; set; }

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
