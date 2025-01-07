using Cinema.Domain.Constants;

namespace Cinema.Application.User.Dtos;

public record UserDto
{
    public int Id { get; set; }
    public string Email { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateOnly? BirthDate { get; set; }
    public Role Role { get; set; }
    
    public string FullName => $"{FirstName} {LastName}";
}
