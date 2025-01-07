namespace Cinema.Application.User;

public interface IUserContext
{
    CurrentUser? GetCurrentUser();
}