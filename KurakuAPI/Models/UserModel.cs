using System.ComponentModel.DataAnnotations;

namespace KurakuAPI.Models;

public class UserModel
{
    public long Id { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public DateTime? BirthDate { get; set; }
}
