using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Entities;

public class Profile
{
    [Required]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    [Display(Name = "UserId")]
    public string UserId { get; set; }

    [ForeignKey("UserId")]
    public IdentityUser User { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public DateOnly BirthDate { get; set; }
}
