using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

public class Accomodation
{
    [Required]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    public string HotelName { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public DateTime CheckInDate { get; set; }

    [Required]
    public DateTime CheckOutDate { get; set;}

    [Required]
    [Display(Name = "ItineraryId")]
    public long ItineraryId { get; set; }

    [ForeignKey("ItineraryId")]
    public Itinerary Itinerary { get; set; }
}
