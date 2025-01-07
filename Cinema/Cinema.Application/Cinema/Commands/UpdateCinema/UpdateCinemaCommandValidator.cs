using FluentValidation;

namespace Cinema.Application.Cinema.Commands.UpdateCinema;

public class UpdateCinemaCommandValidator : AbstractValidator<UpdateCinemaCommand>
{
    public UpdateCinemaCommandValidator()
    {
        RuleFor(dto => dto.Name).Length(3, 50);
    }
}