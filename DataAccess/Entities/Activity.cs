using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

public class Activity
{
    [Required]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    [Display(Name = "ItineraryId")]
    public long ItineraryId { get; set; }

    [ForeignKey("ItineraryId")]
    public Itinerary Itinerary { get; set; }
}
