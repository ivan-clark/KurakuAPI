using Microsoft.AspNetCore.Identity;

namespace KurakuAPI.Models;

public class ProfileModel
{
    public long Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Address { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public DateOnly BirthDate { get; set; }
}
