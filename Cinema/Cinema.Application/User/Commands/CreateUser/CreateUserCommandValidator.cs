using FluentValidation;

namespace Cinema.Application.User.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Name is required")
            .Length(2, 50).WithMessage("Name must be between 2 and 50 characters")
            .Matches("^[a-zA-Z]+$").WithMessage("Name must only contain letters");
        
        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Surname is required")
            .Length(2, 50).WithMessage("Surname must be between 2 and 50 characters")
            .Matches("^[a-zA-Z]+$").WithMessage("Surname must only contain letters");
        
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email address is required")
            .EmailAddress().WithMessage("Please enter a valid email address");
        
        RuleFor(x => x.BirthDate)
            .NotNull().WithMessage("Date birth is required")
            .LessThan(DateOnly.FromDateTime(DateTime.Now)).WithMessage("Date birth must be in the past.");
        
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required")
            .Length(3, 40).WithMessage("Username must be between 3 and 40 characters");
        
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches("[0-9]").WithMessage("Password must contain at least one digit.")
            .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");
        
        RuleFor(x => x.ConfirmPassword)
            .NotEmpty().WithMessage("Password is required")
            .Equal(x => x.Password).WithMessage("Password and confirm password must match.");
    }
}