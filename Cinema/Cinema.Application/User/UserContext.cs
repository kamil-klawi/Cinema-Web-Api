using System.Security.Claims;
using Cinema.Domain.Constants;
using Microsoft.AspNetCore.Http;

namespace Cinema.Application.User;

public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public CurrentUser? GetCurrentUser()
    {
        var user = httpContextAccessor.HttpContext?.User;
        
        if (user == null)
            throw new InvalidOperationException("User context is null");
        
        if (user.Identity == null || !user.Identity.IsAuthenticated)
            return null;
        
        var userId = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var userFirstName = user.FindFirst(c => c.Type == "FirstName")!.Value;
        var userLastName = user.FindFirst(c => c.Type == "LastName")!.Value;
        var userEmail = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;
        var userRoles = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
        var birthDateString = user.FindFirst(c => c.Type == "BirthDate")?.Value;
        var birthDate = birthDateString == null 
            ? (DateOnly?) null 
            : DateOnly.ParseExact(birthDateString, "yyyy-MM-dd");

        var enumerable = userRoles.ToList();
        if (enumerable.Contains(Role.ADMIN.ToString()))
            return new CurrentUser(userId, userFirstName, userLastName, userEmail, Role.ADMIN, birthDate);
        
        if (enumerable.Contains(Role.USER.ToString()))
            return new CurrentUser(userId, userFirstName, userLastName, userEmail, Role.USER, birthDate);
        
        return null;
    }
}