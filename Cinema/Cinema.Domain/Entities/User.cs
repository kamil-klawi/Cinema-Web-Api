using Cinema.Domain.Constants;
using Microsoft.AspNetCore.Identity;

namespace Cinema.Domain.Entities;

public class User : IdentityUser
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateOnly? BirthDate { get; set; }
    public Role Role { get; set; }
}