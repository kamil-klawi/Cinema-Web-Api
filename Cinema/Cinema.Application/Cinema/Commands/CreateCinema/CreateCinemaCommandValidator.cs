using FluentValidation;

namespace Cinema.Application.Cinema.Commands.CreateCinema;

public class CreateCinemaCommandValidator : AbstractValidator<CreateCinemaCommand>
{
    public CreateCinemaCommandValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(dto => dto.EmailAddress).EmailAddress().WithMessage("Email address is required.");
        RuleFor(dto => dto.ZipCode).Matches(@"^\d{2}-\d{3}$").WithMessage("Zip code is invalid.");
    }
}