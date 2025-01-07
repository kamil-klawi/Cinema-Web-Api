using Cinema.Domain.Constants;

namespace Cinema.Application.User;

public record CurrentUser (string Id, string FirstName, string LastName, string Email, Role Role, DateOnly? BirthDate)
{
    
}